namespace KickScooters
{
    public class InputData
    {
        /// <summary>
        ///  AmountKickScooters = n
        /// </summary>
        public int AmountKickScooters { get; set; }
        /// <summary>
        ///  AmountCarParks = m
        /// </summary>
        public int AmountCarParks { get; set; }
        /// <summary>
        ///  AmountCars = k
        /// </summary>
        public int AmountCars { get; set; }
        /// <summary>
        ///  Следующие n + m + 1 строчек содержат по n + m + 1 чисел — матрицу расстояний D (0 ≤ D(i, j) ≤ 10^5, 0 ≤ i, j ≤ n + m). В i-й (0 ≤ i ≤ n + m) строчке заданы элементы D(i, 0), D(i, 1), …, D(i, n + m).
        ///  Гарантируется, что на главной диагонали матрицы расположены нули. При этом матрица может и не быть симметричной.
        /// </summary>
        public int[,] DistanceMatrix { get; set; }
        /// <summary>
        ///  k положительных чисел d1, d2, …, dk (0 ≤ di ≤ 105) — ограничения на длину маршрутов автомобилей.
        /// </summary>
        public int[] MaxDistances { get; set; }
    }
}
