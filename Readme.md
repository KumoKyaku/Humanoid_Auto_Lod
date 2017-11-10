使用 simplygon 插件自动LOD
人形角色LOD的使用，处理LOD切换时动画播放问题

视频教程：https://www.bilibili.com/video/av16154340/


备注：在生成人形角色LOD的时候骨骼顺序发生了改变，用常规替换mesh和重新绑定骨骼的方法不能与原模型兼容。
现在的Animator Rebind会在切换LOD时出现一帧的Tpose。
也许我应该生成LOD的时候生成一个面数为元模型的新模型来取代元模型，用来实现LOD0和LOD1兼容。
