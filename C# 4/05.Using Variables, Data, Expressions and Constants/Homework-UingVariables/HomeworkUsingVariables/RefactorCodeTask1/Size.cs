namespace RefactorCodeTask1
{
    using System;

    /// <summary>
    /// Store figure size - width and height.
    /// </summary>
    public class Size
    {
        /// <summary>
        /// Store figure width.
        /// </summary>
        private double width;

        /// <summary>
        /// Store figure height.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="width">Figure width.</param>
        /// <param name="height">Figure height</param>
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets or sets figure width.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets figure height.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Calculate size of figure after rotation.
        /// </summary>
        /// <param name="figureSize">Figure size.</param>
        /// <param name="rotationAngle">Rotation angle of figure.</param>
        /// <returns>New Size</returns>
        public static Size GetRotatedSize(Size figureSize, double rotationAngle)
        {
            double figureWidth = (Math.Abs(Math.Cos(rotationAngle)) * figureSize.width) +
                                 (Math.Abs(Math.Sin(rotationAngle)) * figureSize.height);
            double figureHeight = (Math.Abs(Math.Sin(rotationAngle)) * figureSize.width) +
                                  (Math.Abs(Math.Cos(rotationAngle)) * figureSize.height);
            Size result = new Size(figureWidth, figureHeight);

            return result;
        }
    }
}
