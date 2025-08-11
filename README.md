# Trystage Launcher

此commit仅做了写装饰性修改及少量feature

### Features:
- UI改动: 使用Visual Studio的WinForm设计器把UI的控件声明部分转移到TrystageLauncher.Designer.cs文件中。
- 在选择Java 8路径旁边添加了一个浏览磁盘文件的按钮
- 添加了一个退出按钮

### 修改 ~~(只有部分修改因为我记不全了)~~
- 加了些MessageBox的图标
- 为了UI不爆炸，窗口的大小是固定的，不能最大化但是能最小化
- 图标什么的图像资源移到了Res文件夹
- 略微改动了点代码
- ...

### 有个Issue
- 所有的网络资源下载的URL都会Time out掉

> 
    string remoteVersionUrl = "http://rcn.zyghit.cn/trystage/version.txt"; //version check url
    string ClientzipUrl = "http://rcn.zyghit.cn/trystage/TrystageClient.zip"; //Client Zip,contain assets,library,and version
    string JavazipUrl = "http://rcn.zyghit.cn/trystage/jre8.zip"; //Java Zip,using zulu tsmp mirrior,unzip will get jre8 folder
