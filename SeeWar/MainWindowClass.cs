using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SeeWar
{
    public class MainWindowClass : Control
    {
        public MainWindowClass() : base()
        {
            _cellSize = 30;
            _cellPadding = 3;
            _ShipColor.Add(Color.White);
            _ShipColor.Add(Color.Red);
            _ShipColor.Add(Color.Green);
            _ShipColor.Add(Color.Blue);
            _ShipColor.Add(Color.Yellow);
            //если мимо
            _ShipColor.Add(Color.Olive);
            //если попал
            _ShipColor.Add(Color.Black);
        }
        private int[,] _playerField = new int[10, 10];
        private int[,] _botField = new int[10, 10];
        private char[] _aplhabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
        private List<Color> _ShipColor = new List<Color>();
        private int _cellSize;
        private int _cellPadding;
        private bool _startGame = false;
        private List<int> fistingHuman = new List<int>();
        private List<int> fistingBot = new List<int>();
        //Свойства
        public bool StartGame
        {
            private get { return _startGame; }
            set { if (_startGame != value) _startGame = value; }
        }
        private int CellSize
        {
            get { return _cellSize; }
            set
            {
                if (value != _cellSize)
                {
                    _cellSize = value;
                    Invalidate();
                }
            }
        }
        private int CellPadding
        {
            get { return _cellPadding; }
            set
            {
                if (value != _cellPadding)
                {
                    _cellPadding = value;
                    Invalidate();
                }
            }
        }
        //оптимизация отображения
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        //функция изменения размеров окна
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (width > Math.Min(height, width)) width = height;
            else height = width;
            base.SetBoundsCore(x, y, width, height, specified);
        }
        //Основная функция отрисовки изображения
        protected override void OnPaint(PaintEventArgs e)
        {
            //отрисовка фона
            Rectangle backgroung = new Rectangle(0, 0, Width, Height);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), backgroung);

            //отрисовка полей
            PlayerField(e);
            BotField(e);
        }
        //поле для игрока
        private void PlayerField(PaintEventArgs e)
        {
            Rectangle cellRectangle;
            Brush cellColor = new SolidBrush(Color.White);
            int cellSize = CellSize + CellPadding;
            //text
            int fontSize = CellSize / 3;
            Font font = new Font("Segoe Script", fontSize);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //для всех последующих ячеек пользователя
            for (int i = 0; i < _playerField.GetLength(0); i++)
            {
                for (int j = 0; j < _playerField.GetLength(1); j++)
                {
                    cellRectangle = new Rectangle(cellSize * (i + 1), cellSize * (j + 1), _cellSize, _cellSize);
                    e.Graphics.FillRectangle(new SolidBrush(_ShipColor[_playerField[i, j]]), cellRectangle);
                }
                //number
                cellRectangle = new Rectangle(_cellPadding, cellSize * (i + 1), _cellSize, _cellSize);
                e.Graphics.DrawString((i + 1).ToString(), font, new SolidBrush(Color.Black), cellRectangle, sf);
                //alphabet
                cellRectangle = new Rectangle(cellSize * (i + 1), _cellPadding, _cellSize, _cellSize);
                e.Graphics.DrawString(_aplhabet[i].ToString(), font, new SolidBrush(Color.Black), cellRectangle, sf);
            }
        }
        //поле для бота
        private void BotField(PaintEventArgs e)
        {
            Rectangle cellRectangle;
            int cellSize = CellSize + CellPadding;
            //text
            int fontSize = CellSize / 3;
            Font font = new Font("Segoe Script", fontSize);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //для всех последующих ячеек бота
            for (int i = 0; i < _botField.GetLength(0); i++)
            {
                for (int j = 0; j < _botField.GetLength(1); j++)
                {
                    cellRectangle = new Rectangle(cellSize * (i + _botField.GetLength(0) + 3), cellSize * (j + 1), _cellSize, _cellSize);
                    e.Graphics.FillRectangle(new SolidBrush(_ShipColor[_botField[j, i]]), cellRectangle);
                }
                //number
                cellRectangle = new Rectangle(cellSize * (_botField.GetLength(0) + 2), cellSize * (i + 1), _cellSize, _cellSize);
                e.Graphics.DrawString((i + 1).ToString(), font, new SolidBrush(Color.Black), cellRectangle, sf);
                //alphabet
                cellRectangle = new Rectangle(cellSize * (i + _botField.GetLength(0) + 3), _cellPadding, _cellSize, _cellSize);
                e.Graphics.DrawString(_aplhabet[i].ToString(), font, new SolidBrush(Color.Black), cellRectangle, sf);
            }
        }
        //стрельба из лука
        public void onClickListener(Point MousePos)
        {
            if (StartGame)
            {
                if (fistingBot.Count == 0)
                {
                    fistingBot.Add(0);
                }
                if (fistingBot[fistingBot.Count - 1] == 0)
                {
                    Point MousePos1 = PointToClient(MousePos);

                    int _xCor = MousePos1.Y / (_cellSize + _cellPadding); // норм
                    int _yCor = (MousePos1.X - 430) / (_cellSize + _cellPadding); // норм

                    if (_xCor >= 1) --_xCor;
                    if (_xCor >= 10) _xCor = 9;
                    if (_xCor < 0) _xCor = 0;

                    if (_yCor >= 10) _yCor = 9;
                    if (_yCor >= 10) _yCor = 9;
                    if (_yCor < 0) _yCor = 0;

                    //mimo
                    if (_botField[_xCor, _yCor] == 0)
                    {
                        _botField[_xCor, _yCor] = 5;
                        fistingHuman.Add(0);
                    }

                    //popal
                    if (_botField[_xCor, _yCor] > 0 && _botField[_xCor, _yCor] < 5)
                    {
                        _botField[_xCor, _yCor] = 6;
                        fistingHuman.Add(1);
                    }
                }


                if (fistingHuman[fistingHuman.Count - 1] == 0)
                {
                    do
                    {
                        //бот хуярит
                        Random rand = new Random();
                        int _yCor, _xCor;
                        do
                        {
                            _xCor = rand.Next(0, 10);
                            _yCor = rand.Next(0, 10);
                        } while (_playerField[_xCor, _yCor] == 5 || _playerField[_xCor, _yCor] == 6);

                        if (_playerField[_xCor, _yCor] == 0)
                        {
                            _playerField[_xCor, _yCor] = 5;
                            fistingBot.Add(0);
                        }
                        if (_playerField[_xCor, _yCor] > 0 && _playerField[_xCor, _yCor] < 5)
                        {
                            _playerField[_xCor, _yCor] = 6;
                            fistingBot.Add(1);
                        }
                    } while (fistingBot[fistingBot.Count - 1] == 1);
                }

                Invalidate();
            }
            else
            {
                MessageBox.Show("ИГРА НЕ НАЧАТА", "ВНИМАНИЕ");
            }

        }
        //расставить корабли рандомно
        public void ShipPlaceRandom(bool BotOrHuman)
        {
            int[,] cell;
            if (BotOrHuman) cell = _playerField;
            else cell = _botField;


            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    cell[i, j] = 0;

            Random random = new Random();
            int countShipInField = 9;
            int valueShip;
            do
            {
                int numberRandom = random.Next(0, 9);
                int aplhabetRandom = random.Next(0, 9);
                bool place;
                //расположение корабля
                if (random.Next(10, 100) % 2 == 0) place = true;
                else place = false;

                //какой корабль ставить
                if (countShipInField == 9) valueShip = 4;
                else if (countShipInField >= 7 && countShipInField < 9) valueShip = 3;
                else if (countShipInField >= 4 && countShipInField < 7) valueShip = 2;
                else if (countShipInField >= 0 && countShipInField < 4) valueShip = 1;
                else valueShip = 1;

                if (cell[numberRandom, aplhabetRandom] == 0)
                {
                    if (AddShipPlaceFieldHorizontalVertical(numberRandom, aplhabetRandom, valueShip, place, cell))
                        --countShipInField;
                }
            }
            while (countShipInField >= 0);
            Invalidate();
        }
        //проверка горизон. вертик.
        private bool AddShipPlaceFieldHorizontalVertical(int i, int j, int valueShip, bool place, int[,] cell)
        {

            if (RealPlaceLeftAndRight(i, j, valueShip, cell, place) && 
                RealPlaceAngle(i, j, valueShip, cell, place) &&
                RealPlaceTopBottom(i, j, valueShip, cell, place))
            {
                if (place)
                {
                    for (int count = valueShip; count != 0; ++j)
                    {
                        cell[i, j] = valueShip;
                        --count;
                    }
                    return true;
                } else
                {
                    for (int count = valueShip; count != 0; ++i)
                    {
                        cell[i, j] = valueShip;
                        --count;
                    }
                    return true;
                }
            }

            return false;
        }
        //справа и слева проверка +
        private bool RealPlaceLeftAndRight(int i, int j, int valueShip, int[,] cell, bool place)
        {
            if (place)
            {
                int cnt = 0;
                //сверху
                if (j > 0)
                {
                    if (cell[i, j - 1] == 0) cnt++;
                }
                else cnt++;
                //снизу
                if (j + valueShip < 9)
                {
                    if (cell[i, j + valueShip] == 0) cnt++;
                }
                else cnt++;
                if (cnt == 2) return true;
                else return false;
            }
            else
            {
                int cnt = 0;
                int valueShipBot = valueShip;
                if (j < 9 && i + valueShip <= 9)
                {
                    //справа вертикаль проверить
                    do
                    {
                        if (cell[i, j + 1] == 0)
                            cnt++;
                        ++i;
                        --valueShipBot;
                    } while (valueShipBot != 0);
                    //слева вертикаль проверить
                    valueShipBot = valueShip;
                    if (j > 0 && i + valueShip <= 9)
                    {
                        do
                        {
                            if (cell[i, j - 1] == 0)
                                cnt++;
                            ++i;
                            --valueShipBot;
                        } while (valueShipBot != 0);
                    }
                }
                if (cnt == valueShip * 2) return true;
                else return false;
            }
        }
        //если по краям можно добавить +
        private bool RealPlaceAngle(int i, int j, int valueShip, int[,] cell, bool place)
        {
            if (place)
            {
                int cnt = 0;
                //сверху слева
                if (i != 0 && j != 0)
                {
                    if (cell[i - 1, j - 1] == 0) cnt++;
                }
                else cnt++;
                //сверху справа
                if (i != 0 && j + valueShip <= 9)
                {
                    if (cell[i - 1, j + valueShip] == 0) cnt++;
                }
                else cnt++;
                //снизу слева
                if (i < 9 && j != 0)
                {
                    if (cell[i + 1, j - 1] == 0) cnt++;
                }
                else cnt++;
                //снизу справа
                if (i != 9 && j + valueShip <= 9)
                {
                    if (cell[i + 1, j + valueShip] == 0) cnt++;
                }
                else cnt++;
                if (cnt == 4) return true;
                else return false;
            }
            else
            {
                //lefttopAndRight
                int cnt = 0;
                if (i - 1 >= 0 && j - 1 >= 0)
                {
                    if (cell[i - 1, j - 1] == 0) cnt++;
                }
                else cnt++;
                if (i - 1 >= 0 && j + 1 <= 9)
                {
                    if (cell[i - 1, j + 1] == 0) cnt++;
                }
                else cnt++;
                //BottomLeftAndRight
                if (i + valueShip <= 9 && j > 0)
                {
                    if (cell[i + valueShip, j - 1] == 0) cnt++;
                }
                else cnt++;
                if (i + valueShip <= 9 && j != 9)
                {
                    if (cell[i + valueShip, j + 1] == 0) cnt++;
                }
                else cnt++;
                if (cnt == 4) return true;
                else return false;
            }
        }
        //сверху и снизу проверка +
        private bool RealPlaceTopBottom(int i, int j, int valueShip, int[,] cell, bool place)
        {
            if (place)
            {
                int cnt = 0;
                int valueShipBot = valueShip;

                if (j + valueShip < 9 && i > 0)
                {
                    //сверху
                    do
                    {
                        if (cell[i - 1, j] == 0)
                            cnt++;
                        ++j;
                        --valueShipBot;
                    } while (valueShipBot != 0);
                }
                else cnt += 2;

                valueShipBot = valueShip;
                //снизу
                if (i < 9 && j + valueShip <= 9)
                {
                    do
                    {
                        if (cell[i + 1, j] == 0)
                            cnt++;
                        ++j;
                        --valueShipBot;
                    } while (valueShipBot != 0);
                }
                else cnt += 2;

                if (cnt == valueShip * 2) return true;
                else return false;
            }
            else
            {
                int cnt = 0;
                //сверху
                if (i > 0)
                {
                    if (cell[i - 1, j] == 0) cnt++;
                }
                else cnt++;
                //снизу
                if (i + valueShip < 9)
                {
                    if (cell[i + valueShip, j] == 0) cnt++;
                }
                else cnt++;
                if (cnt == 2) return true;
                else return false;
            }
        }
    }
}
