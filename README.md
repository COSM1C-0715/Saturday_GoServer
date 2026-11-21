# Saturday_GoServer

Unity クライアントプロジェクト。Go サーバーの API (`items` エンドポイント) と連携するゲームクライアントです。

## 環境

- Unity 6000.3.8f1
- Universal Render Pipeline 17.3.0
- Input System 1.19.0

## セットアップ

1. Unity Hub で上記バージョンのエディタをインストールする
2. このリポジトリを clone し、Unity Hub から開く
3. `Assets/Scenes/SampleScene.unity` または `Assets/Scenes/CharacterScene.unity` を開いて再生する

## ディレクトリ構成 (`Assets/Scripts`)

| パス | 内容 |
| --- | --- |
| `ApiClient.cs`, `CreateItemRequest.cs`, `ItemList.cs` | サーバー API との通信 |
| `character/` | プレイヤー・敵・ステータス |
| `InputSystem/` | 入力処理 |
| `UIScript/` | キャラクターステータス UI |
| `Utility/` | Static オブジェクト、時間管理などの共通処理 |
| `Interface/` | `IDamage`, `IKnockBack` |
| `Bullet.cs`, `GenericSpawnSystem.cs`, `SpawnManagement.cs` | 弾・スポーン |

## ブランチ運用

`develop` から作業ブランチを切り、PR で `develop` にマージします。
