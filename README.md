# Notify Slack Web Meeting Admin

当日の Web 会議情報を Slack に通知するサービスの管理アプリケーションです。

## 事前準備

- VSCode を利用可能にする。

- NodeJS をインストール

  https://nodejs.org/ja/download

- Azure Function Core Tools をインストール

  `npm i -g azure-functions-core-tools@4 --unsafe-perm true`

## ローカル環境での実行

### 1. 依存パッケージをインストールする

`npm install` を実行し、クライアントアプリケーションの依存パッケージをインストールします。

### 2. クライアントアプリケーションをビルドする

`npm run build`を実行し、クライアントアプリケーションをビルドします。

### 3. DB のへ接続設定を構築する

1. DB の接続文字列の取得を参考に DB 接続文字列を取得する
   `api/local.setting.json`に以下の設定を追加する。

```js
  "CosmosDBConnectionString": "取得したDB接続文字列"
```

### 4. CLI を起動する

`swa start build --api-location api`を実行し、Static Web Apps CLI を起動します。
CLI プロセスが開始したら、http://localhost:4280/ からアプリにアクセスします。

### 参考

https://learn.microsoft.com/ja-jp/azure/static-web-apps/add-api?tabs=react

## Azure Static WebApps へのデプロイ

### 1. VSCode に Azure Static Web Apps 拡張機能をインストールする

1. [表示]>[拡張機能] を選択します。
2. [Marketplace で拡張機能を検索する] で、「Azure Static Web Apps」と入力します。
3. Azure Static Web Apps で [インストール] を選択します。
4. 拡張機能が Visual Studio Code にインストールされます。

### 2. Azure Static Web Apps を作成する

拡張機能で Azure Static Web Apps を作成する。

1. 名前には管理アプリケーション名を指定します。
2. リージョンは「Japan East」を指定します。
3. ビルド設定は「React」を指定します。

その他のパラメータは以下の通りです。

```js
  アプリケーションコードの場所: "/",
  ビルドプログラムの場所: "build"
```

### DB への接続設定を構築する

1. Azure portal にアクセスし作成した Static Web Apps を表示します。
2. サイドナビの[設定] > [構成] を選択します。
3. [+追加]を選択し、アプリ設定を追加します。
4. [名前]に"CosmosDBConnectionString"を指定します。
5. DB の接続文字列の取得で取得した値を[値]に DB 接続文字列を指定します。
6. [OK]を選択します。
7. [保存]を選択します。

### 3. デプロイを確認する

デプロイが完了したら、Static Web Apps 拡張機能で作成したプロジェクトを右クリックし、[サイトの参照]を選択するとデプロイ先のサイトにアクセスできます。

アクセス後以下の手順で DB のデータが取得できていることを確認します。

1. サイドナビのログインボタンを押します。
2. Microsoft アカウントでのログイン画面にリダイレクト後ログイン処理を実行します。
3. サイドナビでユーザー一覧を選択し、ユーザー一覧画面を表示します。

### 参考

https://learn.microsoft.com/ja-jp/azure/static-web-apps/getting-started?tabs=react#create-a-static-web-app

## DB の接続文字列の取得

1. Azure portal にアクセスします。
2. 接続先の Azure Cosmos DB アカウントを表示します。
3. サイドナビの[設定] > [キー]を選択します。
4. [読み取り/書き込みキー]の[プライマリ接続文字列]をコピーします。
