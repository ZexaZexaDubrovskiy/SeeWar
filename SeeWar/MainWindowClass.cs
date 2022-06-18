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

            _ShipColor.Add(Color.Olive);
        }
        private int[,] _playerField = new int[10, 10];
        private int[,] _botField = new int[10, 10];
        private char[] _aplhabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
        private int[,] _botShip = new int[,] { { 4, 1 }, { 3, 2 }, { 2, 3 }, { 1, 4 } };
        private List<Color> _ShipColor = new List<Color>();
        private int _cellSize;
        private int _cellPadding;

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
        //СДЕЛАТЬ ЕГО ПРОТЕКТЕД
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
                    e.Graphics.FillRectangle(cellColor, cellRectangle);
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

        public void click()
        {
            Invalidate();
        }
        //расстановка кораблей
        public void ShipPlaceRandom()
        {
            Random random = new Random();
            int countShipInField = 9;
            int valueShip;
            do
            {
                int numberRandom = random.Next(0, 9);
                int aplhabetRandom = random.Next(0, 9);
                bool place = true;
                //расположение корабля
                if (random.Next(10, 100) % 2 == 0) place = true;
                else place = false;

                //какой корабль ставить
                if (countShipInField == 9) valueShip = 4;
                else if (countShipInField >= 7 && countShipInField < 9) valueShip = 3;
                else if (countShipInField >= 4 && countShipInField < 7) valueShip = 2;
                else if (countShipInField >= 0 && countShipInField < 4) valueShip = 1;
                else valueShip = 1;

                if (_botField[numberRandom, aplhabetRandom] == 0)
                {
                    if (AddShipPlaceFieldHorizontalVertical(numberRandom, aplhabetRandom, valueShip, place))
                        --countShipInField;
                }
            }
            while (countShipInField >= 0);
            // _botField[9, 9] = 10;
        }
        //Функция добавления корабля на поле
        private bool AddShipPlaceFieldHorizontalVertical(int i, int j, int valueShip, bool place)
        {
            if (place)
            {
                if (RealPlaceRightHorizontal(i, j, valueShip) && RealPlaceLeftHorizontal(i, j)
                    && RealPlaceTopSecretHorizontal(i, j, valueShip) && RealPlaceBottomSecretHorizontal(i, j, valueShip)
                    && RealPlaceTopRightAndBottomRightHorizontal(i, j, valueShip))
                {
                    for (int count = valueShip; count != 0; ++j)
                    {
                        _botField[i, j] = valueShip;
                        --count;
                    }
                    return true;
                }
            }
            else
            {
                if (i + valueShip <= 9 &&
                    RealPlaceTopBottomVertical(i, j, valueShip) &&
                    RealPlaceRightVertical(i, j, valueShip) &&
                    RealPlaceLeftVertical(i, j, valueShip) &&
                    RealPlaceTopRightAndBottomRightVertical(i, j, valueShip)
                    )
                {
                    for (int count = valueShip; count != 0; ++i)
                    {
                        _botField[i, j] = valueShip;
                        --count;
                    }
                    return true;
                }
            }


            return false;
        }

        // для горизонтали
        //проверка что можно добавить справа + справа нет корабля
        private bool RealPlaceRightHorizontal(int i, int j, int valueShip)
        {
            switch (valueShip)
            {
                case 4:
                    {
                        if (j <= 5 && _botField[i, j + 1] == 0 && _botField[i, j + 2] == 0
                            && _botField[i, j + 3] == 0 && _botField[i, j + 4] == 0) return true;
                        else if (j <= 6 && _botField[i, j + 1] == 0 && _botField[i, j + 2] == 0
                            && _botField[i, j + 3] == 0) return true;
                        else return false;
                    }
                case 3:
                    {
                        if (j <= 6 && _botField[i, j + 1] == 0 && _botField[i, j + 2] == 0
                            && _botField[i, j + 3] == 0) return true;
                        else if (j <= 7 && _botField[i, j + 1] == 0 && _botField[i, j + 2] == 0)
                            return true;
                        else return false;
                    }
                case 2:
                    {
                        if (j <= 7 && _botField[i, j + 1] == 0 && _botField[i, j + 2] == 0) return true;
                        else if (j == 8 && _botField[i, j + 1] == 0) return true;
                        else return false;
                    }
                case 1:
                    {
                        if (j <= 8 && _botField[i, j + 1] == 0) return true;
                        else if (j == 9) return true;
                        else return false;
                    }
            }
            return false;
        }
        //проверка что можно добавить слева + слева нет корабля
        private bool RealPlaceLeftHorizontal(int i, int j)
        {
            if (j == 0) return true;
            else if (j >= 1 && _botField[i, j - 1] == 0) return true;
            else return false;
        }
        //если сверху можно поставить
        private bool RealPlaceTopSecretHorizontal(int i, int j, int valueShip)
        {
            int cnt = 0;
            int valueShipBot = valueShip;
            if (i != 0)
            {
                do
                {
                    if (_botField[i - 1, j] == 0)
                        cnt++;
                    ++j;
                    --valueShipBot;
                } while (valueShipBot != 0);
            }
            else return true;
            if (cnt == valueShip) return true;
            else return false;
        }
        //если снизу можно добавить
        private bool RealPlaceBottomSecretHorizontal(int i, int j, int valueShip)
        {
            int cnt = 0;
            int valueShipBot = valueShip;
            if (i != 9)
            {
                do
                {
                    if (_botField[i + 1, j] == 0)
                        cnt++;
                    j++;
                    --valueShipBot;
                } while (valueShipBot != 0);
            }
            else return true;

            if (cnt == valueShip) return true;
            else return false;
        }
        //если по краям можно добавить
        private bool RealPlaceTopRightAndBottomRightHorizontal(int i, int j, int valueShip)
        {
            int cnt = 0;
            if (j + valueShip <= 9 && i != 0)
            {
                if (_botField[i - 1, j + valueShip] == 0) cnt++;
            }
            else cnt++;
            if (j + valueShip <= 9 && i != 9)
            {
                if (_botField[i + 1, j + valueShip] == 0) cnt++;
            }
            else cnt++;
            if (i != 0 && j != 0)
            {
                if (_botField[i - 1, j - 1] == 0) cnt++;
            }
            else cnt++;
            if (i != 9 && j != 0)
            {
                if (_botField[i + 1, j - 1] == 0) cnt++;
            }
            else cnt++;
            if (cnt == 4) return true;
            else return false;
        }

        //для вертикали перепиши что сверху под низ. А то так короче
        //если по краям можно добавить
        private bool RealPlaceTopRightAndBottomRightVertical(int i, int j, int valueShip)
        {
            //lefttopAndRight
            int cnt = 0;
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                if (_botField[i - 1, j - 1] == 0) cnt++;
            }
            else cnt++;
            if (i - 1 >= 0 && j + 1 <= 9)
            {
                if (_botField[i - 1, j + 1] == 0) cnt++;
            }
            else cnt++;
            //BottomLeftAndRight
            if (i + valueShip <= 9 && j > 0)
            {
                if (_botField[i + valueShip, j - 1] == 0) cnt++;
            }
            else cnt++;
            if (i + valueShip <= 9 && j != 9)
            {
                if (_botField[i + valueShip, j + 1] == 0) cnt++;
            }
            else cnt++;
            if (cnt == 4) return true;
            else return false;
        }
        //если справа нет корабля
        private bool RealPlaceRightVertical(int i, int j, int valueShip)
        {
            int cnt = 0;
            int valueShipBot = valueShip;
            if (j < 9 && i + valueShip <= 9)
            {
                do
                {
                    if (_botField[i, j + 1] == 0)
                        cnt++;
                    ++i;
                    --valueShipBot;
                } while (valueShipBot != 0);
            }
            else return true;
            if (cnt == valueShip) return true;
            else return false;
        }
        //если слева нет корабля
        private bool RealPlaceLeftVertical(int i, int j, int valueShip)
        {
            int cnt = 0;
            int valueShipBot = valueShip;
            if (j > 0 && i + valueShip <= 9)
            {
                do
                {
                    if (_botField[i, j - 1] == 0)
                        cnt++;
                    ++i;
                    --valueShipBot;
                } while (valueShipBot != 0);
            }
            else return true;
            if (cnt == valueShip) return true;
            else return false;
        }
        //сверху и снизу проверка
        private bool RealPlaceTopBottomVertical(int i, int j, int valueShip)
        {
            int cnt = 0;
            //сверху
            if (i > 0)
            {
                if (_botField[i - 1, j] == 0) cnt++;
            }
            else cnt++;
            //снизу
            if (i + valueShip < 9)
            {
                if (_botField[i + valueShip, j] == 0) cnt++;
            }
            else cnt++;
            if (cnt == 2) return true;
            else return false;
        }


        private List<int> Coordinate = new List<int>();
        public void onClickListener(Point MousePos)
        {
            Point MousePos1 = PointToClient(MousePos);

            int _xCor = (MousePos1.Y) / (_cellSize + _cellPadding); // норм
            int _yCor = (MousePos1.X) / (_cellSize* _cellPadding); // не норм

            if ( _xCor >= 1) --_xCor;
            if (_xCor >= 10) _xCor = 9;



            if (_yCor >= 10) _yCor = 9;

            if (_botField[_xCor, _yCor] == 0)
            {
                _botField[_xCor, _yCor] = 5;
            }

            Invalidate();
        }

        public void updateArray()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    _botField[i, j] = 0;
        }
    }
}
