# UnityGames

Unity 游戏与交互功能练习合集。每个子目录都是独立 Unity 工程，请通过 Unity Hub 分别打开，不要把仓库根目录作为一个工程打开。

## 工程导航

| 工程 | 内容 | 入口场景（相对工程目录） |
| --- | --- | --- |
| `ParkourSystemCourse` | 塔防：炮塔建造、敌人波次、攻击、胜负判断和菜单；保留原工程名称 | `Assets/Scenes/MainMenu.unity` |
| `SurvivalShooter` | 生存射击：角色移动、射击、敌人追踪、生命值和计分 | 练习场景 `Assets/Scenes/Level 01.unity`；当前构建入口为教学完成版 `Assets/_CompletedAssets/Scenes/Level 01 5.x.unity` |
| `2DGame` | 2D 角色移动、方向动画及攻击动画演示 | `Assets/Scenes/SampleScene.unity` |
| `2DBlendTree` | 角色行走、奔跑、持枪转向、动画混合与相机控制演示 | `Assets/Scenes/SampleScene.unity` |
| `3DMoonRunner` | 外部开源项目的本地学习副本：3D 跑酷、金币、障碍和道具 | `Assets/main.unity` |

## 打开与构建

所有工程当前 `ProjectVersion.txt` 均记录 **Unity 2021.3.9f1c1**。优先使用对应版本打开，首次导入会重新生成 Library 并恢复 Packages 中记录的依赖，可能需要联网。

打开对应入口场景后可在编辑器中尝试 Play。本次整理仅验证工程文件与资源副本完整性，未启动 Unity、执行编译或验证实际运行。

- `2DBlendTree` 的构建场景列表为空；如需打包，请先将上述场景加入 Build Settings。
- `SurvivalShooter` 保留练习脚本与 `_CompletedAssets` 教学完成版。当前 Build Settings 选择完成版，展示练习版本时请明确选择相应场景。没有删除完成版资源，以避免破坏现有引用。
- `2DGame` 和 `2DBlendTree` 属于交互功能演示，不代表完整关卡游戏。

## 收录范围

各工程保留 `Assets/`（含 `.meta`）、`Packages/` 与 `ProjectSettings/`。资源内容和 GUID 原样复制；仅将外层目录 `Survival Shooter/Survival Shooter` 整理为 `SurvivalShooter`，`3DMoonRunner-master` 整理为 `3DMoonRunner`。

不收录 Unity/IDE 缓存、生成的解决方案、打包产物、独立安装包和素材包、中文课件目录及未选中的其他工程。`TheBallDefense` 属于塔防工程的 Windows 构建产物，本仓库保留其源码工程 `ParkourSystemCourse`。

## 来源与许可

- `3DMoonRunner` 原 README 指向 XINCGer/3DMoonRunner；原作者标注为“马三小伙儿”。已保留原 README、预览图片与 MIT LICENSE，本仓库不将其声明为原创作品。原 README 的 Unity 2018 版本信息为上游历史信息，以当前 ProjectVersion 为本地版本记录。
- `SurvivalShooter` 包含教学完成版和示例资源；`ParkourSystemCourse` 为塔防课程实践工程。
- 各工程的第三方模型、贴图、音频与依赖保留其现有许可说明；本合集不为第三方素材重新授予统一许可。
