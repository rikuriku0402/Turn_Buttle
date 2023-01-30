# ターン制バトル

今回のゲームはMVPパターンで作りました

## MVPクラス

- [Model](https://github.com/rikuriku0402/Turn_Buttle/tree/master/Assets/Script/Model)
- [View](https://github.com/rikuriku0402/Turn_Buttle/tree/master/Assets/Script/View)
- [Presenter](https://github.com/rikuriku0402/Turn_Buttle/tree/master/Assets/Script/Presenter)

# モデルの説明(ここではPlayerで考えています)

## モデルの説明

このモデルクラスでは体力を設定しておいて
ダメージなどを引く場合Damage()を呼んであげると体力が減るようになっています。

## ビューの説明

このビュークラスでは体力バーや攻撃ボタンなどを管理しています。

Attack(),Defence()などで攻撃や防御をします。
後々中身の説明をします。
あくまでもボタンなどを管理するだけなので実装は別です。

## プレゼンター

このプレゼンタークラスではモデルクラスとビュークラスを中継するやくです。


## バトルシステム

# バトルクラス

このバトルクラスではモデルクラスを参照しHpを取ってきて
攻撃力を変数で持たせておいてAttack()で攻撃力からHpを減らす関数を用意してビューで呼ぶ。

# 使用アセット

UniRX
UniTask
