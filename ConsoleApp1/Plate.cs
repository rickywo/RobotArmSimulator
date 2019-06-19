using System;

namespace ConsoleApp1
{
    /* Plate Class*/
    /// <summary>
    /// Plate Class.
    /// The main class that simulate the robot arm and wells grid
    /// </summary>
    class Plate
    {
        // Array index start from 0 but 1,1 is the south west of the grid
        public static readonly int OFFSET = 1;

        // Vector that defines the movement in a vector form, movement can be
        // simply interpreted in a set of vector operations.
        public static readonly Vec[] DirectVects =
        {
            new Vec(0, 1), new Vec(1, 0), new Vec(-1, 0), new Vec(0, -1)
        };

        // _dimension defines the grid size
        private readonly Vec _dimension;
        // It hold the current robot arm position
        private Vec _arm_pos;
        // The indicator that indicates if place command is performed or not
        private bool _initialized;
        
        // 2d array holds wells status in bool
        bool[,] _wells;

        public Plate(int n, int m)
        {
            _dimension = new Vec(n, m);
            _wells = new bool[n, m];
            _initialized = false;
            ResetWells(false);
        }

        // Place function that places robot arm t0 a specific coordinates on the grid
        public void Place(int x, int y)
        {
            var tempPos = new Vec(x, y);
            if (CheckInsideRange(tempPos))
            {
                _arm_pos = new Vec(x, y);
                _initialized = true;
            }
            else
            {
                throw new System.ArgumentException("Coordinates out of range");
            }
        }

        // Move robot arm to any direction
        // Example: Move(Direction N)
        // Current pos = (1, 2)
        // Move North => (1, 2) + (0, 1)
        // Current pos = (0, 3)
        public void Move(Direction direction)
        {
            CheckInitStatus();
            var tempPos = _arm_pos + DirectVects[(int) direction];
            if (CheckInsideRange(tempPos))
            {
                _arm_pos = tempPos;
            }
        }

        // Report function displays the current position and status of a wells
        public void Report()
        {
            CheckInitStatus();
            Console.WriteLine(
                $"{_arm_pos.x + OFFSET},{_arm_pos.y + OFFSET},{(_wells[_arm_pos.x, _arm_pos.y] ? "Full" : "Empty")}");
        }

        // Drop function fill up a well at current position
        public void Drop()
        {
            CheckInitStatus();
            _wells[_arm_pos.x, _arm_pos.y] = true;
        }

        // ResetWells resets all wells to empty state
        private void ResetWells(bool value)
        {
            for (int i = 0; i < _dimension.x; i++)
            {
                for (int j = 0; j < _dimension.y; j++)
                    _wells[i, j] = value;
            }
        }

        // Check if given coordinates is in the NxM grid
        private bool CheckInsideRange(Vec vec) =>
            (vec.x >= 0 && vec.x < _dimension.x
                        && vec.y >= 0 && vec.y < _dimension.y);

        // Check if Place function is performed
        private void CheckInitStatus()
        {
            if (!_initialized) throw new System.InvalidOperationException("Invalid Operation");
        }
    }
}