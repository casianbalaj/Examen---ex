using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SubnauticaGraphics
{
    public partial class MainForm : Form
    {
        private Bitmap canvas = null!;
        private Graphics graphics = null!;
        private Random random;
        private const int CanvasWidth = 800;
        private const int CanvasHeight = 600;

        public MainForm()
        {
            InitializeComponent();
            random = new Random(42);
            InitializeCanvas();
            this.Load += MainForm_Load;
        }

        private void InitializeCanvas()
        {
            canvas = new Bitmap(CanvasWidth, CanvasHeight);
            graphics = Graphics.FromImage(canvas);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            DrawScene();
            pictureBox.Image = canvas;
        }

        private void DrawScene()
        {
            DrawObjective1_MarineGradient();
            DrawObjective3_Submarine();
            ApplyObjective4_GaussianBlur();
            DrawObjective7_FractalCorals();
            DrawObjective8_LSystemAlgae();
            DrawObjective6_Fish();
            DrawObjective5_TrafficSign();
            DrawObjective2_Flag();
        }

        private void DrawObjective1_MarineGradient()
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, CanvasWidth, CanvasHeight),
                Color.FromArgb(0, 40, 80),
                Color.FromArgb(0, 120, 160),
                LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, 0, 0, CanvasWidth, CanvasHeight);
            }
        }

        private void DrawObjective2_Flag(int flagNumber = 1)
        {
            int x = 8;
            int y = CanvasHeight - 100 - 8;
            int width = 161;
            int height = 100;

            switch (flagNumber)
            {
                case 1:
                    DrawAlgeriaFlag(x, y, width, height);
                    break;
                default:
                    DrawAlgeriaFlag(x, y, width, height);
                    break;
            }
        }

        private void DrawAlgeriaFlag(int x, int y, int width, int height)
        {
            using (SolidBrush greenBrush = new SolidBrush(Color.FromArgb(0, 122, 51)))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush redBrush = new SolidBrush(Color.FromArgb(210, 16, 52)))
            {
                graphics.FillRectangle(greenBrush, x, y, width / 2, height);
                graphics.FillRectangle(whiteBrush, x + width / 2, y, width / 2, height);

                int centerX = x + width / 2;
                int centerY = y + height / 2;
                int outerRadius = (int)(height * 0.25);
                int innerRadius = (int)(outerRadius * 0.66);

                graphics.FillEllipse(redBrush, centerX - outerRadius, centerY - outerRadius, outerRadius * 2, outerRadius * 2);
                graphics.FillEllipse(whiteBrush, centerX - innerRadius + 5, centerY - innerRadius, innerRadius * 2, innerRadius * 2);

                DrawStar(centerX + 8, centerY, (int)(height * 0.15), redBrush);
            }
        }

        private void DrawStar(int centerX, int centerY, int radius, Brush brush)
        {
            PointF[] points = new PointF[10];
            double angle = -Math.PI / 2;
            for (int i = 0; i < 10; i++)
            {
                double r = (i % 2 == 0) ? radius : radius * 0.4;
                points[i] = new PointF(
                    (float)(centerX + r * Math.Cos(angle)),
                    (float)(centerY + r * Math.Sin(angle))
                );
                angle += Math.PI / 5;
            }
            graphics.FillPolygon(brush, points);
        }

        private void DrawObjective3_Submarine()
        {
            int subX = 150;
            int subY = 400;
            float angle = -10f;

            graphics.TranslateTransform(subX, subY);
            graphics.RotateTransform(angle);

            using (SolidBrush darkGrayBrush = new SolidBrush(Color.FromArgb(180, 80, 85, 75)))
            using (SolidBrush rustBrush = new SolidBrush(Color.FromArgb(180, 139, 90, 43)))
            using (SolidBrush greenGrayBrush = new SolidBrush(Color.FromArgb(180, 95, 100, 85)))
            using (Pen outlinePen = new Pen(Color.FromArgb(60, 65, 55), 2))
            {
                Rectangle mainBody = new Rectangle(0, 20, 200, 40);
                graphics.FillRectangle(darkGrayBrush, mainBody);
                graphics.DrawRectangle(outlinePen, mainBody);

                graphics.FillPie(greenGrayBrush, 195, 20, 40, 40, -90, 180);
                graphics.DrawPie(outlinePen, 195, 20, 40, 40, -90, 180);

                Rectangle tower = new Rectangle(70, 0, 50, 30);
                graphics.FillRectangle(rustBrush, tower);
                graphics.DrawRectangle(outlinePen, tower);

                PointF[] propeller1 = new PointF[]
                {
                    new PointF(230, 40),
                    new PointF(250, 35),
                    new PointF(245, 40)
                };
                graphics.FillPolygon(darkGrayBrush, propeller1);

                PointF[] propeller2 = new PointF[]
                {
                    new PointF(230, 40),
                    new PointF(250, 45),
                    new PointF(245, 40)
                };
                graphics.FillPolygon(darkGrayBrush, propeller2);

                for (int i = 0; i < 4; i++)
                {
                    graphics.FillEllipse(rustBrush, 10 + i * 15, 28, 8, 8);
                }

                for (int i = 0; i < 25; i++)
                {
                    int rx = random.Next(0, 200);
                    int ry = random.Next(20, 60);
                    graphics.FillEllipse(rustBrush, rx, ry, 3, 3);
                }

                for (int i = 0; i < 8; i++)
                {
                    int rx = random.Next(0, 200);
                    int ry = random.Next(20, 60);
                    using (SolidBrush lineBrush = new SolidBrush(Color.FromArgb(120, 160, 140, 90)))
                    {
                        graphics.DrawLine(new Pen(lineBrush, 1), rx, ry, rx + random.Next(10, 30), ry);
                    }
                }

                PointF[] damage1 = new PointF[]
                {
                    new PointF(150, 25),
                    new PointF(160, 28),
                    new PointF(155, 35),
                    new PointF(148, 32)
                };
                graphics.FillPolygon(rustBrush, damage1);

                PointF[] damage2 = new PointF[]
                {
                    new PointF(30, 55),
                    new PointF(40, 58),
                    new PointF(38, 60),
                    new PointF(32, 59)
                };
                graphics.FillPolygon(rustBrush, damage2);
            }

            graphics.ResetTransform();
        }

        private void ApplyObjective4_GaussianBlur()
        {
            Rectangle submarineRegion = new Rectangle(100, 350, 300, 120);
            Bitmap regionBitmap = new Bitmap(submarineRegion.Width, submarineRegion.Height);

            using (Graphics g = Graphics.FromImage(regionBitmap))
            {
                g.DrawImage(canvas, new Rectangle(0, 0, submarineRegion.Width, submarineRegion.Height),
                    submarineRegion, GraphicsUnit.Pixel);
            }

            Bitmap blurred = ApplyGaussianBlur(regionBitmap, 2.0);
            graphics.DrawImage(blurred, submarineRegion.Location);
            blurred.Dispose();
            regionBitmap.Dispose();
        }

        private Bitmap ApplyGaussianBlur(Bitmap source, double sigma)
        {
            int size = (int)Math.Ceiling(sigma * 3) * 2 + 1;
            double[,] kernel = CreateGaussianKernel(size, sigma);

            Bitmap result = new Bitmap(source.Width, source.Height);
            int offset = size / 2;

            BitmapData srcData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* dstPtr = (byte*)dstData.Scan0;

                for (int y = 0; y < source.Height; y++)
                {
                    for (int x = 0; x < source.Width; x++)
                    {
                        double r = 0, g = 0, b = 0, a = 0, weightSum = 0;

                        for (int ky = 0; ky < size; ky++)
                        {
                            for (int kx = 0; kx < size; kx++)
                            {
                                int pixelY = y + ky - offset;
                                int pixelX = x + kx - offset;

                                if (pixelX >= 0 && pixelX < source.Width && pixelY >= 0 && pixelY < source.Height)
                                {
                                    int pixelOffset = (pixelY * srcData.Stride) + (pixelX * 4);
                                    double weight = kernel[ky, kx];

                                    b += srcPtr[pixelOffset] * weight;
                                    g += srcPtr[pixelOffset + 1] * weight;
                                    r += srcPtr[pixelOffset + 2] * weight;
                                    a += srcPtr[pixelOffset + 3] * weight;
                                    weightSum += weight;
                                }
                            }
                        }

                        int dstOffset = (y * dstData.Stride) + (x * 4);
                        dstPtr[dstOffset] = (byte)Math.Min(255, Math.Max(0, b / weightSum));
                        dstPtr[dstOffset + 1] = (byte)Math.Min(255, Math.Max(0, g / weightSum));
                        dstPtr[dstOffset + 2] = (byte)Math.Min(255, Math.Max(0, r / weightSum));
                        dstPtr[dstOffset + 3] = (byte)Math.Min(255, Math.Max(0, a / weightSum));
                    }
                }
            }

            source.UnlockBits(srcData);
            result.UnlockBits(dstData);
            return result;
        }

        private double[,] CreateGaussianKernel(int size, double sigma)
        {
            double[,] kernel = new double[size, size];
            double sum = 0;
            int offset = size / 2;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int dx = x - offset;
                    int dy = y - offset;
                    kernel[y, x] = Math.Exp(-(dx * dx + dy * dy) / (2 * sigma * sigma)) / (2 * Math.PI * sigma * sigma);
                    sum += kernel[y, x];
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    kernel[y, x] /= sum;
                }
            }

            return kernel;
        }

        private void DrawObjective5_TrafficSign()
        {
            int x = 550;
            int y = 450;
            int size = 60;

            graphics.TranslateTransform(x, y);
            graphics.RotateTransform(8);

            using (SolidBrush redBrush = new SolidBrush(Color.FromArgb(220, 200, 30, 30)))
            using (SolidBrush whiteBrush = new SolidBrush(Color.FromArgb(220, 240, 240, 230)))
            using (SolidBrush algaeBrush = new SolidBrush(Color.FromArgb(150, 60, 120, 70)))
            using (Pen rustPen = new Pen(Color.FromArgb(150, 120, 80, 50), 2))
            {
                PointF[] triangle = new PointF[]
                {
                    new PointF(0, -size),
                    new PointF(-size * 0.866f, size / 2),
                    new PointF(size * 0.866f, size / 2)
                };

                graphics.FillPolygon(redBrush, triangle);
                graphics.DrawPolygon(rustPen, triangle);

                PointF[] innerTriangle = new PointF[]
                {
                    new PointF(0, -size * 0.7f),
                    new PointF(-size * 0.6f, size * 0.3f),
                    new PointF(size * 0.6f, size * 0.3f)
                };
                graphics.FillPolygon(whiteBrush, innerTriangle);

                for (int i = 0; i < 5; i++)
                {
                    int ax = random.Next(-size, size);
                    int ay = random.Next(-size, size / 2);
                    graphics.FillEllipse(algaeBrush, ax, ay, 8, 12);
                }

                using (Pen rustPost = new Pen(Color.FromArgb(180, 100, 70, 40), 5))
                {
                    graphics.DrawLine(rustPost, 0, size / 2, 0, size + 40);
                }
            }

            graphics.ResetTransform();
        }

        private void DrawObjective6_Fish()
        {
            for (int i = 0; i < 15; i++)
            {
                int fishX = random.Next(50, 750);
                int fishY = random.Next(100, 500);
                float fishSize = (float)(random.NextDouble() * 0.5 + 0.5);
                Color fishColor = GetRandomFishColor();
                DrawSingleFish(fishX, fishY, fishSize, fishColor);
            }
        }

        private Color GetRandomFishColor()
        {
            Color[] colors = new Color[]
            {
                Color.FromArgb(200, 255, 140, 50),
                Color.FromArgb(200, 50, 150, 200),
                Color.FromArgb(200, 255, 200, 80),
                Color.FromArgb(200, 150, 100, 255),
                Color.FromArgb(200, 255, 100, 150)
            };
            return colors[random.Next(colors.Length)];
        }

        private void DrawSingleFish(int x, int y, float scale, Color color)
        {
            graphics.TranslateTransform(x, y);
            graphics.ScaleTransform(scale, scale);

            using (SolidBrush bodyBrush = new SolidBrush(color))
            using (SolidBrush eyeBrush = new SolidBrush(Color.Black))
            {
                graphics.FillEllipse(bodyBrush, -15, -8, 30, 16);

                PointF[] tail = new PointF[]
                {
                    new PointF(-15, 0),
                    new PointF(-30, -12),
                    new PointF(-25, 0),
                    new PointF(-30, 12)
                };
                using (GraphicsPath tailPath = new GraphicsPath())
                {
                    tailPath.AddBezier(tail[0], tail[1], tail[2], tail[3]);
                    graphics.FillPath(bodyBrush, tailPath);
                }

                PointF[] topFin = new PointF[]
                {
                    new PointF(0, -8),
                    new PointF(5, -18),
                    new PointF(8, -8)
                };
                graphics.FillPolygon(bodyBrush, topFin);

                PointF[] sideFin = new PointF[]
                {
                    new PointF(-5, 8),
                    new PointF(-8, 15),
                    new PointF(-2, 10)
                };
                graphics.FillPolygon(bodyBrush, sideFin);

                graphics.FillEllipse(eyeBrush, 8, -3, 4, 4);
            }

            graphics.ResetTransform();
        }

        private void DrawObjective7_FractalCorals()
        {
            DrawFractalTree(200, 520, -90, 6, 25, Color.FromArgb(200, 255, 100, 150));
            DrawFractalTree(320, 530, -90, 6, 22, Color.FromArgb(200, 150, 100, 255));
            DrawFractalTree(180, 480, -85, 5, 28, Color.FromArgb(200, 255, 150, 100));
            DrawFractalTree(420, 510, -95, 6, 30, Color.FromArgb(200, 100, 255, 200));
            DrawFractalTree(280, 540, -88, 5, 25, Color.FromArgb(200, 255, 200, 100));
            DrawFractalTree(360, 525, -92, 6, 27, Color.FromArgb(200, 200, 100, 255));
        }

        private void DrawFractalTree(float x, float y, float angle, int depth, float length, Color baseColor)
        {
            if (depth == 0) return;

            float radian = (float)(angle * Math.PI / 180);
            float x2 = x + length * (float)Math.Cos(radian);
            float y2 = y + length * (float)Math.Sin(radian);

            int colorShift = (6 - depth) * 30;
            Color branchColor = Color.FromArgb(
                baseColor.A,
                Math.Min(255, baseColor.R + colorShift),
                Math.Min(255, baseColor.G - colorShift / 2),
                Math.Max(0, baseColor.B - colorShift)
            );

            using (Pen pen = new Pen(branchColor, Math.Max(1, depth * 1.5f)))
            {
                graphics.DrawLine(pen, x, y, x2, y2);
            }

            DrawFractalTree(x2, y2, angle - 30, depth - 1, length * 0.7f, baseColor);
            DrawFractalTree(x2, y2, angle + 30, depth - 1, length * 0.7f, baseColor);
        }

        private void DrawObjective8_LSystemAlgae()
        {
            string algae1 = GenerateLSystem("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F]F" } }, 4);
            DrawLSystem(650, 580, algae1, 22, 5, Color.FromArgb(200, 100, 180, 100));

            string algae2 = GenerateLSystem("F", new Dictionary<char, string> { { 'F', "FF+[+F-F-F]-[-F+F+F]" } }, 3);
            DrawLSystem(120, 560, algae2, 25, 4, Color.FromArgb(200, 80, 150, 90));

            string algae3 = GenerateLSystem("X", new Dictionary<char, string> { { 'X', "F+[[X]-X]-F[-FX]+X" }, { 'F', "FF" } }, 4);
            DrawLSystem(500, 570, algae3, 20, 3, Color.FromArgb(200, 120, 200, 110));
        }

        private string GenerateLSystem(string axiom, Dictionary<char, string> rules, int iterations)
        {
            string current = axiom;
            for (int i = 0; i < iterations; i++)
            {
                string next = "";
                foreach (char c in current)
                {
                    next += rules.ContainsKey(c) ? rules[c] : c.ToString();
                }
                current = next;
            }
            return current;
        }

        private void DrawLSystem(float startX, float startY, string lsystem, float angle, float length, Color color)
        {
            Stack<Tuple<float, float, float>> stack = new Stack<Tuple<float, float, float>>();
            float x = startX;
            float y = startY;
            float currentAngle = -90;

            using (Pen pen = new Pen(color, 1.5f))
            {
                foreach (char c in lsystem)
                {
                    switch (c)
                    {
                        case 'F':
                        case 'X':
                            float radian = (float)(currentAngle * Math.PI / 180);
                            float newX = x + length * (float)Math.Cos(radian);
                            float newY = y + length * (float)Math.Sin(radian);
                            if (c == 'F')
                            {
                                graphics.DrawLine(pen, x, y, newX, newY);
                            }
                            x = newX;
                            y = newY;
                            break;
                        case '+':
                            currentAngle += angle;
                            break;
                        case '-':
                            currentAngle -= angle;
                            break;
                        case '[':
                            stack.Push(Tuple.Create(x, y, currentAngle));
                            break;
                        case ']':
                            if (stack.Count > 0)
                            {
                                var state = stack.Pop();
                                x = state.Item1;
                                y = state.Item2;
                                currentAngle = state.Item3;
                            }
                            break;
                    }
                }
            }
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = "ExGraf_Nume_Prenume.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    canvas.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Image saved successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRedraw_Click(object? sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            DrawScene();
            pictureBox.Invalidate();
        }
    }
}
