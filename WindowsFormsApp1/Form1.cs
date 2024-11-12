using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private DifficultyLevel currentDifficulty = DifficultyLevel.Medium;
        private Timer gameTimer;
        private Timer spawnZombieTimer;
        private Timer currencyTimer;
        private Timer wavePauseTimer;
        private List<Zombie> zombies;
        private List<Tower> towers;
        private PointF[] pathPoints;
        private int baseHealth = 3;
        private int currency = 100;
        private int wave = 1;
        private int HP = 75;
        private int zombiesPerWave = 3;
        private int zombiesRemainingInWave = 0;
        private ProgressBar superAbilityProgressBar;
        private const int zombiesToChargeSuperAbility = 20;
        private int zombiesKilled = 0;
        private Button btnSuperAbility;
        private const float fixedZombieSpeed = 1.5f;
        private ContextMenuStrip towerContextMenu;

        private int knightTowerCount = 0;
        private int archerTowerCount = 0;
        private int magicTowerCount = 0;
        private readonly int maxKnightTowers = 5;
        private readonly int maxArcherTowers = 12;
        private readonly int maxMagicTowers = 10;

        private enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard
        }

        private Image zombieIcon;
        private Image magicTowerIcon;
        private Image archerTowerIcon;
        private Image knightTowerIcon;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            InitializeFarm();
            InitializeMenu();
            InitializeIcons();
            InitializeTowerContextMenu();
            InitializeSuperAbilityProgressBar();
            InitializeSuperAbilityButton();
            btnSuperAbility.BackColor = Color.IndianRed;
            
        }
        private int farmLevel = 0;
        private int farmIncome = 0;
        private int farmUpgradeCost = 25;
        private Timer farmIncomeTimer;

        int mag = 0, arc = 0, KN = 0;


        private void InitializeTowerContextMenu()
        {
            towerContextMenu = new ContextMenuStrip();
            var deleteMenuItem = new ToolStripMenuItem("Видалити башню", null, DeleteTower);
            towerContextMenu.Items.Add(deleteMenuItem);
            BTNFarm.BackColor = Color.Yellow;
            
        }

        private void InitializeIcons()
        {

            zombieIcon = Image.FromFile("C:\\Users\\Андрей\\OneDrive\\Desktop\\WindowsFormsApp1\\WindowsFormsApp1\\WindowsFormsApp1\\img\\zombieIcon.png");
            magicTowerIcon = Image.FromFile("C:\\Users\\Андрей\\OneDrive\\Desktop\\WindowsFormsApp1\\WindowsFormsApp1\\WindowsFormsApp1\\img\\magicTowerIcon.png");
            archerTowerIcon = Image.FromFile("C:\\Users\\Андрей\\OneDrive\\Desktop\\WindowsFormsApp1\\WindowsFormsApp1\\WindowsFormsApp1\\img\\archerTowerIcon.png");
            knightTowerIcon = Image.FromFile("C:\\Users\\Андрей\\OneDrive\\Desktop\\WindowsFormsApp1\\WindowsFormsApp1\\WindowsFormsApp1\\img\\knightTowerIcon.png");
        }
        private bool IsPointInTower(Point point, Tower tower)
        {
            var towerRect = new RectangleF(tower.Position.X - 25, tower.Position.Y - 25, 50, 50); // враховуємо розмір башні
            return towerRect.Contains(point);
        }

        private void DeleteTower(object sender, EventArgs e)
        {
            var tower = towerContextMenu.Tag as Tower;
            if (tower != null)
            {
                int towerCost = 0;

               
                if (tower is MagicTower)
                    towerCost = 150;
                else if (tower is ArcherTower)
                    towerCost = 100;
                else if (tower is KnightTower)
                    towerCost = 50;

                
                currency += towerCost / 2;
                towers.Remove(tower); 
                UpdateCurrencyLabel(); 
                Invalidate();
            }
        }


        private void InitializeMenu()
        {
            var menuStrip = new MenuStrip();
            var settingsMenu = new ToolStripMenuItem("Налаштування");

            var difficultyMenu = new ToolStripMenuItem("Складність");
            difficultyMenu.DropDownItems.Add("Легка", null, (s, e) => SetDifficulty(DifficultyLevel.Easy));
            difficultyMenu.DropDownItems.Add("Нормальна", null, (s, e) => SetDifficulty(DifficultyLevel.Medium));
            difficultyMenu.DropDownItems.Add("Важка", null, (s, e) => SetDifficulty(DifficultyLevel.Hard));
            settingsMenu.DropDownItems.Add(difficultyMenu);
            var restartGameMenu = new ToolStripMenuItem("Перезапустити гру", null, (s, e) => RestartGame());
            settingsMenu.DropDownItems.Add(restartGameMenu);
            var closeGameMenu = new ToolStripMenuItem("Close Game", null, (s, e) => Close());
            settingsMenu.DropDownItems.Add(closeGameMenu);

            menuStrip.Items.Add(settingsMenu);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
        }
        private void RestartGame()
        {
            baseHealth = 3;
            currency = 100;
            wave = 1;
            HP = 75;
            zombiesKilled = 0;
            zombiesRemainingInWave = 0;
            towers.Clear();
            zombies.Clear();
            superAbilityProgressBar.Value = 0;
            btnSuperAbility.Enabled = false;

            InitializeGame();
            MessageBox.Show("Гру перезапущено!", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateCurrencyLabel();
            Invalidate();
        }
        private void BtnSuperAbility_Click(object sender, EventArgs e)
        {
            ActivateSuperAbility();
        }
        private void InitializeSuperAbilityProgressBar()
        {
            superAbilityProgressBar = new ProgressBar();
            superAbilityProgressBar.Maximum = zombiesToChargeSuperAbility;
            superAbilityProgressBar.Value = 0;
            superAbilityProgressBar.Location = new Point(10, 100);
            superAbilityProgressBar.Size = new Size(150, 20);
            Controls.Add(superAbilityProgressBar);
        }
        private void InitializeSuperAbilityButton()
        {
            btnSuperAbility = new Button();
            btnSuperAbility.Text = "Суперспособность";
            btnSuperAbility.Location = new Point(10, 130);
            btnSuperAbility.Size = new Size(150, 30);
            btnSuperAbility.Enabled = false;
            btnSuperAbility.Click += BtnSuperAbility_Click;
            Controls.Add(btnSuperAbility);
        }
        private void SetDifficulty(DifficultyLevel level)
        {
            currentDifficulty = level;
            switch (level)
            {
                case DifficultyLevel.Easy:
                    HP = 100;
                    currency = 200;
                    break;
                case DifficultyLevel.Medium:
                    HP = 150;
                    currency = 100;
                    break;
                case DifficultyLevel.Hard:
                    HP = 200;
                    currency = 50;
                    break;
            }
            MessageBox.Show($"Складність: {level}. Монет: {currency}.");
            UpdateCurrencyLabel();
        }

        //private void ZombieKilled1(Zombie zombie)
        //{
        //    zombiesKilled++;
        //    superAbilityProgressBar.Value = Math.Min(zombiesKilled, zombiesToChargeSuperAbility);

        //    if (zombiesKilled >= zombiesToChargeSuperAbility)
        //    {
        //        btnSuperAbility.Enabled = true;
        //        MessageBox.Show("ВИКОРИСТАЙ СУПЕРСПОСОБНОСТЬ");
        //    }

        //    UpdateCurrencyLabel();
        //}
        private void ActivateSuperAbility()
        {
            if (zombiesKilled < zombiesToChargeSuperAbility)
            {
                MessageBox.Show("Суперспособность ще не готова", "Гра", MessageBoxButtons.OK);
                return;
            }

            foreach (var zombie in zombies)
            {
                if (!zombie.IsDead)
                {
                    zombie.IsDead = true;
                }
            }

            zombies.RemoveAll(z => z.IsDead);
            Invalidate();

            zombiesKilled = 0;
            superAbilityProgressBar.Value = 0;
            btnSuperAbility.Enabled = false;

            MessageBox.Show("Суперспособность активована", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public class MagicTower : Tower
        {
            
            public MagicTower(PointF position, Form1 form)
                : base(position, 15, 120, form)
            {
                icon = form.magicTowerIcon; 
            }
        }

        public class ArcherTower : Tower
        {
            public ArcherTower(PointF position, Form1 form)
                : base(position, 10, 150, form)
            {
                icon = form.archerTowerIcon; 
            }
        }

        public class KnightTower : Tower
        {
            public KnightTower(PointF position, Form1 form)
                : base(position, 20, 50, form)
            {
                icon = form.knightTowerIcon; 
            }
        }
        private void SpawnZombies()
        {
            spawnZombieTimer = new Timer();
            spawnZombieTimer.Interval = 1000;
            spawnZombieTimer.Tick += (sender, e) =>
            {
                if (zombiesRemainingInWave > 0)
                {
                    zombies.Add(new Zombie(HP, pathPoints[0], fixedZombieSpeed, this));
                    zombiesRemainingInWave--;
                }
                else
                {
                    spawnZombieTimer.Stop();
                }
            };
            spawnZombieTimer.Start();
        }
        private void InitializeFarm()
        {
            
            farmLevel = 0;
            farmIncome = 0;
            farmUpgradeCost = 25;

            
            farmIncomeTimer = new Timer();
            farmIncomeTimer.Interval = 1000; 
            farmIncomeTimer.Tick += AddFarmIncome;
            farmIncomeTimer.Start();
        }
        private void AddFarmIncome(object sender, EventArgs e)
        {
            
            currency += farmIncome;
            UpdateCurrencyLabel();
        }

        private void UpgradeFarm()
        {
            
            if (farmLevel == 0 && currency >= 25)
            {
                currency -= 25;
                farmIncome = 3;
                farmLevel = 1;
                farmUpgradeCost = 25; 
            }
            else if (farmLevel == 1 && currency >= 50)
            {
                currency -= 50;
                farmIncome = 4;
                farmLevel = 2;
                farmUpgradeCost = 50; 
            }
            else if (farmLevel == 2 && currency >= 100)
            {
                currency -= 100;
                farmIncome = 6;
                farmLevel = 3;
                farmUpgradeCost = 0;
            }
            else
            {
                if(farmLevel == 3)
                {
                    MessageBox.Show("Макс. рівень", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не вистачає монет", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }              
            }

            
            label1.Text = $"{farmIncome}/sec";
            UpdateCurrencyLabel();
        }


        private void InitializeGame()
        {
            zombies = new List<Zombie>();
            towers = new List<Tower>();
            pathPoints = new PointF[] { new PointF(0, 450), new PointF(250, 450), new PointF(250, 125), new PointF(560, 125), new PointF(560, 310), new PointF(800, 310) };

            
            gameTimer = new Timer();
            gameTimer.Interval = 50; 
            gameTimer.Tick += GameTick;
            gameTimer.Start();

            
            currencyTimer = new Timer();
            currencyTimer.Interval = 1000; 
            currencyTimer.Tick += AddCurrency;
            currencyTimer.Start();

            
            StartWave();
        }

        private void GameTick(object sender, EventArgs e)
        {
            foreach (var zombie in zombies)
            {
                zombie.Move(pathPoints);
                if (zombie.ReachedBase)
                {
                    baseHealth--;
                    zombie.IsDead = true; 
                    if (baseHealth <= 0)
                    {
                        gameTimer.Stop();
                        MessageBox.Show("ПРОГРАШ!", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }

            
            zombies.RemoveAll(z => z.IsDead);

            
            foreach (var tower in towers)
            {
                tower.Shoot(zombies);
            }

            
            if (zombies.Count == 0 && zombiesRemainingInWave == 0)
            {
                if (wave >= 10)
                {
                    gameTimer.Stop();
                    MessageBox.Show("ПЕРЕМОГА!", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    
                    wave++;
                    StartWave();
                }
            }

            
            Invalidate();
        }

        private void StartWave()
        {
            zombiesRemainingInWave = zombiesPerWave * wave; 

            
            wavePauseTimer = new Timer();
            wavePauseTimer.Interval = 2000; 
            wavePauseTimer.Tick += (sender, e) =>
            {
                wavePauseTimer.Stop();
                SpawnZombies();
            };
            wavePauseTimer.Start();
            HP += 25;
        }

       
        private void AddCurrency(object sender, EventArgs e)
        {
            if(farmLevel == 0)
            {
                currency += 1;
                UpdateCurrencyLabel();
            }
            else
            {
                
            }           
        }

        private void ZombieKilled(Zombie zombie)
        {
            zombiesKilled++;
            superAbilityProgressBar.Value = Math.Min(zombiesKilled, zombiesToChargeSuperAbility);

            if (zombiesKilled >= zombiesToChargeSuperAbility)
            {
                btnSuperAbility.Enabled = true; 
                MessageBox.Show("Суперспособность готова", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateCurrencyLabel();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            var g = e.Graphics;

            
            for (int i = 0; i < pathPoints.Length - 1; i++)
            {
                g.DrawLine(Pens.Gray, pathPoints[i], pathPoints[i + 1]);
            }

            
            foreach (var zombie in zombies)
            {
                zombie.Draw(g);
            }

            
            foreach (var tower in towers)
            {
                tower.Draw(g);
            }

            Font font = new Font("Arial", 16);
            g.DrawString($"ХП: {baseHealth}", font, Brushes.Black, 10, 40);
            g.DrawString($"Волна: {wave}", font, Brushes.Black, 10, 60);
        }

        private void UpdateCurrencyLabel()
        {
            lblCurrency1.Text = $"{currency}";
        }



        public class Zombie
        {
            public int HP { get; set; }
            public PointF Position { get; private set; }
            public float Speed { get; set; }
            public bool IsDead { get; set; }
            public bool ReachedBase { get; private set; }

            private int currentTargetIndex;
            private Form1 form;

            
            private Image icon;

            public Zombie(int hp, PointF startPosition, float speed, Form1 form)
            {
                HP = hp;
                Position = startPosition;
                Speed = speed;
                this.form = form;
                icon = form.zombieIcon; 
            }
            public void Move(PointF[] pathPoints)
            {
                if (ReachedBase || IsDead) return;

                var target = pathPoints[currentTargetIndex];
                var direction = new PointF(target.X - Position.X, target.Y - Position.Y);
                var distance = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

                if (distance < Speed)
                {
                    Position = target;
                    currentTargetIndex++;
                    if (currentTargetIndex >= pathPoints.Length)
                    {
                        ReachedBase = true;
                    }
                }
                else
                {
                    Position = new PointF(Position.X + Speed * (float)(direction.X / distance),
                                          Position.Y + Speed * (float)(direction.Y / distance));
                }
            }

            public void Draw(Graphics g)
            {
                if (icon != null)
                {
                    Image resizedIcon = new Bitmap(icon, new Size(50, 50));
                    g.DrawImage(resizedIcon, Position.X - 20, Position.Y - 20);
                }
                else
                {
                    g.FillEllipse(Brushes.Green, Position.X - 10, Position.Y - 10, 20, 20);
                }
                g.DrawString(HP.ToString(), SystemFonts.DefaultFont, Brushes.Black, Position.X - 10, Position.Y - 25);
            }
        }



        public class Tower
        {
            public PointF Position { get; }
            public int AttackPower { get; }
            public float Range { get; }
            private int cooldown;
            private Form1 form;

            protected Image icon;

            public Tower(PointF position, int attackPower, float range, Form1 form)
            {
                Position = position;
                AttackPower = attackPower;
                Range = range;
                cooldown = 0;
                this.form = form;
            }
            public void Shoot(List<Zombie> zombies)
            {
                if (cooldown > 0)
                {
                    cooldown--;
                    return;
                }

                foreach (var zombie in zombies)
                {
                    if (zombie.IsDead) continue;

                    var distance = Math.Sqrt(Math.Pow(zombie.Position.X - Position.X, 2) + Math.Pow(zombie.Position.Y - Position.Y, 2));

                    if (distance <= Range)
                    {
                        zombie.HP -= AttackPower;

                        if (zombie.HP <= 0)
                        {
                            zombie.HP = 0;
                            zombie.IsDead = true;
                            form.ZombieKilled(zombie);
                        }

                        cooldown = 10;
                        break;
                    }
                }
            }

            public void Draw(Graphics g)
            {
                if (icon != null)
                {
                    Image resizedIcon = new Bitmap(icon, new Size(50, 50));
                    g.DrawImage(resizedIcon, Position.X - 20, Position.Y - 20);
                }
                else
                {
                    g.FillRectangle(Brushes.Blue, Position.X - 25, Position.Y - 25, 20, 20);
                }
            }
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                Tower towerToDelete = towers.FirstOrDefault(tower => IsPointInTower(e.Location, tower));

                if (towerToDelete != null)
                {
                    
                    towerContextMenu.Show(this, e.Location);
                    towerContextMenu.Tag = towerToDelete; 
                }
            }
            else
            {
                
                Tower newTower = null;
                int towerCost = 0;

                if (RBMag.Checked)
                {
                    towerCost = 150;
                    if (currency >= towerCost && magicTowerCount < maxMagicTowers)
                    {
                        newTower = new MagicTower(new PointF(e.X, e.Y), this);
                        magicTowerCount++; 
                    }
                    else if (magicTowerCount >= maxMagicTowers)
                    {
                        MessageBox.Show("Максимальна кількість магів", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (RBArcher.Checked)
                {
                    towerCost = 100;
                    if (currency >= towerCost && archerTowerCount < maxArcherTowers)
                    {
                        newTower = new ArcherTower(new PointF(e.X, e.Y), this);
                        archerTowerCount++;
                    }
                    else if (archerTowerCount >= maxArcherTowers)
                    {
                        MessageBox.Show("Максимальна кількість стрільців", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (RBKnight.Checked)
                {
                    towerCost = 50;
                    if (currency >= towerCost && knightTowerCount < maxKnightTowers)
                    {
                        newTower = new KnightTower(new PointF(e.X, e.Y), this);
                        knightTowerCount++; 
                    }
                    else if (knightTowerCount >= maxKnightTowers)
                    {
                        MessageBox.Show("Максимальна кількість воїнів", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (newTower != null)
                {
                    towers.Add(newTower);
                    currency -= towerCost;
                    UpdateCurrencyLabel();
                    Invalidate();
                }
                else if (newTower == null && towerCost > 0 && currency < towerCost)
                {
                    MessageBox.Show("Не вистачає монет", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Вибери башню", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            lblCurrency1.Text = $"Монетки: {currency}";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void BTNFarm_Click(object sender, EventArgs e)
        {
            UpgradeFarm();
            if(farmLevel == 1)
            {
                BTNFarm.Text = "Покращити - 50";
            }
            else if(farmLevel == 2)
            {
                BTNFarm.Text = "Покращити - 100";
            }
            else if (farmLevel == 3)
            {
                BTNFarm.Text = "Макс. рівень";               
            }


        }

        
    }
}
