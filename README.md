# DFO Clone

## 概要
DFO Cloneは、海外で頒布されているDual Frequency Oscillatorモジュールのクローンで、ゲーム機等の発振器を乗っ取ることで画面の同期周波数を変えたり(NTSC/PAL切り替えなど)するのに使われます。
5Vと3.3Vをジャンパスイッチで切り替えられます。
周波数の設定は、専用の書き込み器でHEXファイルを書き込むことで行います。
周波数設定用のHEXファイルは、Texas Instruments純正のツール [ClockPro](https://www.ti.com/tool/ja-jp/CLOCKPRO)により作成します。

## つかいかた
 - 書き込み器を使って周波数(HEXファイル)を書き込む
HEX書き込みプログラムは[ここ](https://github.com/tceoo1/DFOClone/blob/master/CDCE9xxProg.zip)からダウンロードできます
 - (3.3Vのとき)裏面にあるJP2をハンダでブリッジする
 - 機器に組み込む

