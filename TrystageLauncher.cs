
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Reflection;

namespace trystageClient
{
    
    public partial class TrystageLauncher: Form
    {
        public string ClientVersion = "TrystageClient"; //version in versions folder
        public string ClientzipUrl = "http://files.tsmp.top/TrystageClient.zip"; //Client Zip,contain assets,library,and version
        public string JavazipUrl = "http://files.tsmp.top/jre8.zip"; //Java Zip,using zulu tsmp mirrior,unzip will get jre8 folder
        public string installDir = "C:\\TrystageClient"; //setup folder,must using \ not /
        public string ClientLocation = "C:/TrystageClient"; //Java running Location, using / not \
        public string JavaLocation;
        public async Task InstallJava()
        {

            try
            {
                // 1. 创建目录（无需管理员权限，只要用户有C盘写入权）
                Directory.CreateDirectory(installDir);

                // 2. 下载Zulu JRE（异步）
                string tempZip = Path.GetTempFileName();
                using (WebClient client = new WebClient())
                {
                    await DownloadWithResume(JavazipUrl, tempZip);
                }

                // 3. 解压到目标目录
                ZipFile.ExtractToDirectory(tempZip, installDir);

                // 4. 自动识别解压后的子目录（如zulu8.72.0.17-ca-jre8.0.382-win_x64）
                string jrePath = Directory.GetDirectories(installDir)[0];
                string realJavaPath = Path.Combine(jrePath, "bin", "java.exe");

                MessageBox.Show($"安装成功！Java路径: {realJavaPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"安装失败: {ex.Message}");
            }
        }
        async Task DownloadWithResume(string url, string savePath)
        {
            long existingLength = File.Exists(savePath) ? new FileInfo(savePath).Length : 0;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Range = new RangeHeaderValue(existingLength, null);

                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fs = new FileStream(savePath, FileMode.Append))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fs.WriteAsync(buffer, 0, bytesRead);
                        fs.Flush(); // 确保数据写入磁盘
                    }
                }
            }
        }
        public async Task InstallClient()
        {

            try
            {
                // 1. 创建目录（无需管理员权限，只要用户有C盘写入权）
                Directory.CreateDirectory(installDir);

                // 2. 下载Zulu JRE（异步）
                string tempZip = Path.GetTempFileName();
                using (WebClient client = new WebClient())
                {
                    await DownloadWithResume(ClientzipUrl, tempZip);
                }

                // 3. 解压到目标目录
                ZipFile.ExtractToDirectory(tempZip, installDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"安装游戏失败: {ex.Message}");
            }
        }
        bool IsJava8Installed(String javaLoc)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = javaLoc,
                        Arguments = "-version",
                        RedirectStandardError = true, // Java版本输出到stderr
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                string versionOutput = process.StandardError.ReadToEnd();
                process.WaitForExit();
                // 解析版本输出 (示例输出: java version "1.8.0_301")
                return versionOutput.Contains("version \"1.8") ||
                       versionOutput.Contains("version \"8");
            }
            catch
            {
                return false; // java命令不存在
            }
        }
        string GenerateLaunchArgs(string username, string version)
        {
            return new StringBuilder()
                .Append($"-Xmx2G ")
                .Append($"-Djava.library.path={ClientLocation}/.minecraft/versions/{version}/{version}-natives ")
                .Append($"-cp {GetClassPath(version)} ")
                .Append($"net.minecraft.client.main.Main ")
                .Append($"--username {username} ")
                .Append($"--version {version} ")
                .Append($"--gameDir {ClientLocation}/.minecraft ")
                .Append($"--assetsDir {ClientLocation}/.minecraft/assets ")
                .Append($"--assetIndex 1.8 ")
                .Append($"--uuid {GetOfflineUUID(username)} ")
                .Append($"--accessToken 0 ")
                .Append($"--language zh_cn ")
                .Append($"--userType legacy")
                .ToString();
        }
        public static string GetOfflineUUID(string username)
        {
            // 1. 计算用户名 MD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes("OfflinePlayer:" + username));
                // 2. 转换为 UUID 格式 (8-4-4-4-12)
                return new Guid(hash).ToString();
            }
        }
        string GetClassPath(string version)
        {
            var libs = Directory.GetFiles($"{ClientLocation}/.minecraft/libraries/", "*.jar", SearchOption.AllDirectories);
            // 替换反斜杠为正斜杠
            var normalizedLibs = libs.Select(path => path.Replace('\\', '/'));
            return string.Join(";", normalizedLibs) + $";{ClientLocation}/.minecraft/versions/{version}/{version}.jar";
        }
        public TrystageLauncher()
        {
            InitializeComponent();
            using (Stream ico = Assembly.GetExecutingAssembly().GetManifestResourceStream("trystageClient.Trystage.ico"))
                this.Icon = new Icon(ico);
            this.Text = "TrystageLauncher";
            this.BackgroundImageLayout = ImageLayout.Center;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(300, 400);
            this.MaximumSize = new Size(300, 400);
            this.BackColor = Color.White;
            Label lblTitle = new Label
            {
                Text = "TrystageLauncher",
                Font = new Font("微软雅黑", 20), // 系统自带字体
                Location = new Point(25, 50),
                AutoSize = true // 自动适应文字大小
            };
            this.Controls.Add(lblTitle);

            Label lblPlayerName = new Label
            {
                Text = "用户名:",
                Font = new Font("微软雅黑", 12), // 系统自带字体
                Location = new Point(20, 150),
                AutoSize = true // 自动适应文字大小
            };
            this.Controls.Add(lblPlayerName);
            TextBox txtPlayerName = new TextBox
            {
                Name = "txtPlayerName",
                Location = new Point(85, 150),
                Size = new Size(120, 30),
                ForeColor = Color.DarkBlue,
                BorderStyle = BorderStyle.Fixed3D
            };
            txtPlayerName.Padding = new Padding(10);
            this.Controls.Add(txtPlayerName);
            Label lblJavaLoc = new Label
            {
                Text = "j8地址:",
                Font = new Font("微软雅黑", 12), // 系统自带字体
                Location = new Point(20, 180),
                AutoSize = true // 自动适应文字大小
            };
            this.Controls.Add(lblJavaLoc);
            TextBox txtJavaLocation = new TextBox
            {
                Name = "txtJavaLocation",
                Location = new Point(85, 180),
                Size = new Size(120, 30),
                ForeColor = Color.DarkBlue,
                BorderStyle = BorderStyle.Fixed3D
            };

            txtJavaLocation.Padding = new Padding(10);
            this.Controls.Add(txtJavaLocation);
            // 创建按钮实例
            Button startButton = new Button();

            // 设置属性
            startButton.Name = "startButton";
            startButton.Text = "启动";
            startButton.Location = new Point(100, 240); // X,Y坐标
            startButton.Size = new Size(80, 60);
            startButton.BackColor = Color.LightGray;

            // 添加点击事件
            startButton.Click += async (sender, e) => {
                if(txtPlayerName.TextLength < 3 || txtPlayerName.TextLength > 16)
                {
                    MessageBox.Show("用户名太短或太长!");
                    return;
                }
                if(!txtPlayerName.Text.All(c => c == '_' || (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                {
                    MessageBox.Show("用户名中不可以有中文!");
                    return;
                }
                String javalocs;
                if (txtJavaLocation.Text != "") { javalocs = txtJavaLocation.Text; }
                else { javalocs = "java"; }
                bool hasCustomJava = IsJava8Installed(javalocs);
                bool hasDefaultJava = IsJava8Installed(installDir + "\\jre8\\bin\\java.exe");

                if (!hasCustomJava && !hasDefaultJava)
                {
                    DialogResult result = MessageBox.Show(
                    "你似乎没有j8,是否要安装",
                    "需要JAVA8环境",
                    MessageBoxButtons.OKCancel, // 确定=下载，取消=取消
                    MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("正在为您安装j8!");
                        try
                        {
                            await InstallJava(); // 异步等待
                            MessageBox.Show("安装成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"安装失败: {ex.Message}");
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                    if (hasCustomJava) { JavaLocation = javalocs; }
                    if (hasDefaultJava) { JavaLocation = installDir + "\\jre8\\bin\\java.exe"; }
                if (!Directory.Exists(installDir + "\\.minecraft"))
                {
                    MessageBox.Show("正在为您安装游戏本体!");
                    await InstallClient();
                    MessageBox.Show("安装完毕!");
                    return;
                }
                MessageBox.Show("已找到java和游戏本体!正在启动游戏");
                Process process = new Process();
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"{JavaLocation}\" {GenerateLaunchArgs(txtPlayerName.Text, ClientVersion)} & pause",
                    WorkingDirectory = AppContext.BaseDirectory,
                    UseShellExecute = true
                };
                Process.Start(psi);
            };

            // 将按钮添加到窗体
            this.Controls.Add(startButton);
        }
    }
}
