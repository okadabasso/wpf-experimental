# スタイル命名規則

このプロジェクトでは、統一的なスタイルとリソースキーの命名規則を採用しています。

## 命名規則

### 基本パターン
```
[カテゴリ].[サブカテゴリ].[バリエーション]
```

### 特徴
- **PascalCase** を使用
- **ドット（.）** で階層を区切る
- 意味のある名前を使用

## カテゴリ別命名規則

### 1. 色（Colors）
**パターン**: `Color.[色名].[濃度]`

例:
```xml
<Color x:Key="Color.Rose.50">#fff1f2</Color>
<Color x:Key="Color.Blue.500">#3b82f6</Color>
<Color x:Key="Color.Gray.900">#111827</Color>
```

### 2. ボタン（Buttons）
**パターン**: `Button.[サイズ].[種類]`

例:
```xml
<Style x:Key="Button.Default" TargetType="Button">
<Style x:Key="Button.Small" TargetType="Button">
<Style x:Key="Button.Medium.Primary" TargetType="Button">
<Style x:Key="Button.Small.Secondary" TargetType="Button">
<Style x:Key="OutlineButton.Medium.Danger" TargetType="Button">
```

### 3. フォント（Fonts）
**パターン**: `Font.[プロパティ].[値]`

例:
```xml
<FontFamily x:Key="Font.Awesome">...</FontFamily>
<sys:Double x:Key="Font.Size.Default">14</sys:Double>
<sys:Double x:Key="Font.Size.Small">12</sys:Double>
<sys:Double x:Key="Font.Size.Large">18</sys:Double>
```

### 4. ボタンリソース
**パターン**: `Button.[プロパティ].[値]`

例:
```xml
<CornerRadius x:Key="Button.CornerRadius">4</CornerRadius>
<Thickness x:Key="Button.Padding.Medium">14,7</Thickness>
<Thickness x:Key="Button.Padding.Small">12,6</Thickness>
```

### 5. テキストスタイル
**パターン**: `ButtonText.[種類]`

例:
```xml
<Style x:Key="ButtonText.Default" TargetType="TextBlock">
<Style x:Key="ButtonText.Primary" TargetType="TextBlock">
<Style x:Key="OutlineButtonText.Secondary" TargetType="TextBlock">
```

## 変更履歴

### 2025-10-18
- 初期の命名規則を統一
- `Color_Rose50` → `Color.Rose.50`
- `ButtonCornerRadius` → `Button.CornerRadius`
- `DefaultFontSize` → `Font.Size.Default`
- `FAFont` → `Font.Awesome`

## 注意事項

1. **既存のスタイルを変更する際は、すべての参照箇所を更新してください**
2. **新しいスタイルを追加する際は、この命名規則に従ってください**
3. **VS Code や Visual Studio の検索・置換機能を活用して、一括変更を行ってください**

## 検証

プロジェクトをビルドして、すべての参照が正しく解決されることを確認してください：

```bash
dotnet build
```