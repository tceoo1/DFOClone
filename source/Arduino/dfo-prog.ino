#include <Wire.h>

#define ID "CDCE9XX_PROGRAMMER"
#define FW_VERSION "1.0"
#define FW_DATE "2023/10/21"
#define ERR_NOERROR 0
#define ERR_PROTOCOL 1
#define ERR_I2C 2
#define ERR_VERIFY 3

/******************************************************************************
プロトタイプ
******************************************************************************/
void flushRxFIFO(void);
uint8_t readRegisterFromCDCE9XX(uint8_t deviceAddress,
                uint8_t registerAddress,
                uint8_t* error);
void writeRegisterToCDCE9XX(  uint8_t deviceAddress,
                uint8_t registerAddress,
                uint8_t data,
                uint8_t* error);
uint8_t readProgrammingParameters(void);
uint8_t programCDCE9XX(void);
          
/******************************************************************************
グローバル変数
******************************************************************************/
uint8_t devAddress;     // CDCE9xxのI2Cアドレス
uint8_t nRegisters;     // レジスタ数
uint8_t registers[80];    // CDCE9xxへ書き込むレジスタ値
uint8_t storeEEPROM;    // EEPROMへ保存するか（保存＝1）

void setup() {
  // put your setup code here, to run once:

  Serial.begin(9600);
  Wire.begin();

  Serial.println("Ready");
}

void loop() {
  // put your main code here, to run repeatedly:
  if ( Serial.available() ){
    
    int error = ERR_NOERROR;
    
    switch (Serial.read()){
      
      case '?': 
        // ID
        Serial.println(ID);
        break;
        
      case 'V':
      case 'v':
        // ファームウェアバージョン
        Serial.println(FW_VERSION);
        break;  
                
      case 'D': 
      case 'd':
        // ファームウェア日付
        Serial.println(FW_DATE);
        break;  
                
      case 'W':
      case 'w':
        // 書き込み
        error = readProgrammingParameters();
        if(error)
        {
          Serial.print("ERR:");
          Serial.println(error, HEX);
        }
        else
        {
          Serial.println("OK");
        }
        break;

      case 'r':
      case 'R':
        error = ReadCDCE9XX();
        if(error)
        {
          Serial.print("ERR:");
          Serial.println(error, HEX);
        }
        else
        {
          Serial.println("OK");
        }
        break;

      case 'S':
      case 's':
        //I2Cデバイススキャン
        ScanI2C();
        break;

      case '\r':
      case '\n':
        break;
      
      default:
        error = ERR_PROTOCOL;
        flushRxFIFO();
        Serial.print("ERR:");
        Serial.println(error, HEX);
        break;          
    }
  }
}

uint8_t readProgrammingParameters(void){
  uint8_t error = ERR_NOERROR;
  uint8_t i = 0;
  
  // I2Cアドレス
  while(!Serial.available());
  devAddress = Serial.read();
  if (devAddress > 127) error = ERR_PROTOCOL;
  
  // EEPROMへ書き込みを行うか？
  // 1: 書き込む 0: 書き込まない（電源を切ると設定が消える）
  while(!Serial.available());
  storeEEPROM = Serial.read();
  if (storeEEPROM > 1) error = ERR_PROTOCOL;

  // 書き込むレジスタ数
  while(!Serial.available());
  if (!error) nRegisters = Serial.read();

  if ((nRegisters!=32)&&(nRegisters!=48)&&
    (nRegisters!=64)&&(nRegisters!=80)) error = ERR_PROTOCOL;

  // 書き込むデータ
  if (!error){
    while (i<nRegisters) 
    {
      while(!Serial.available());
      registers[i++] = Serial.read();
    }
  }
  if(error) return error;

  return programCDCE9XX();
}

uint8_t programCDCE9XX(void)
{
  uint8_t error = ERR_NOERROR;
  uint8_t i, temp, register0x06;  

  //レジスタ書き込み
  for(i = 0; i < nRegisters; i++)
  {
    writeRegisterToCDCE9XX(devAddress, i, registers[i], &error);
    if(error) return error;
  }

  //EEPROMへ書き込み
  if (storeEEPROM)
  {
    register0x06 = readRegisterFromCDCE9XX(devAddress, 0x06, &error);
    register0x06 |= (1<<0);
    
    if(error) return error;
    writeRegisterToCDCE9XX(devAddress, 0x06, register0x06, &error);
    
    if(error) return error;
    do{
      temp = readRegisterFromCDCE9XX(devAddress, 0x01, &error);
      if(error) return error;
    }while((temp&(1<<6)));

    register0x06 &= ~(1<<0);
    writeRegisterToCDCE9XX(devAddress, 0x06, register0x06, &error);
    if(error) return error;
  }
  
  //ベリファイ
  for(i = 0; i< nRegisters; i++)
  {
    temp = readRegisterFromCDCE9XX(devAddress, i, &error);
    if(error) return error;
    // Register 0x00 und 0x07 bis 0x0F nicht vergleichen, da read-only bzw. unbestimmt
    if(i == 0x00) continue;
    if(i > 0x06 && i < 0x10) continue;

    if (temp != registers[i]) return ERR_VERIFY;
  }
  return error;
}

uint8_t ReadCDCE9XX(void)
{
  int i, temp;
  uint8_t error = ERR_NOERROR;
  uint8_t n;

  while(!Serial.available());
  devAddress = Serial.read();
  if (devAddress > 127) return 2;// ERR_PROTOCOL;
  while(!Serial.available());
  n = Serial.read();

  for(i = 0; i < n; i++)
  {
    temp = readRegisterFromCDCE9XX(devAddress, i, &error);
    Serial.write((byte)temp);
  }
  
  return error;
}
                
uint8_t readRegisterFromCDCE9XX(uint8_t deviceAddress, 
                uint8_t registerAddress,
                uint8_t* error)
{
  uint8_t data = 0;
  uint8_t err = 0;
    
  Wire.beginTransmission(deviceAddress);
  Wire.write(128 + registerAddress);
  err = Wire.endTransmission();
  if(!err) Wire.requestFrom(deviceAddress, 1);
  if(!err) data = Wire.read();
  
  *error = err;
  return data;
}
              
void writeRegisterToCDCE9XX(uint8_t deviceAddress, 
              uint8_t registerAddress, 
              uint8_t data,
              uint8_t* error)
{
  uint8_t err = 0;
  
  Wire.beginTransmission(deviceAddress);
  Wire.write(128 + registerAddress);
  Wire.write(data);
  err = Wire.endTransmission();
  
  *error = err;
}

void flushRxFIFO(void)
{
  Serial.flush();
  delay(20);
  while(Serial.available()){
    Serial.read();
    delay(20);
  }
}

void ScanI2C(void)
{
  byte error, address;
 
  for(address = 1; address < 127; address++ ) 
  {
    Wire.beginTransmission(address);
    error = Wire.endTransmission();
 
    if (error == 0)
    {
      if (address<16) Serial.print("0");
      Serial.println(address,HEX);
    }
  }
  Serial.println("OK");
}
