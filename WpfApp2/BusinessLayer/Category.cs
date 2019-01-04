namespace WpfApp2.BusinessLayer
{
    public class Category
    {
        #region Properties
        public string CategoryName { get; set; }
        public string Input { get; set; }
        public string Categories { get; set; }
        public int Count { get; set; }
        #endregion

        /// <summary>
        /// Constructor for the Category object
        /// </summary>
        /// <param name="categoryName">the name of the category</param>
        /// <param name="input">the original searching word</param>
        /// <param name="categories"> the category type</param>
        public Category(string categoryName, string input, string categories, int count)
        {
            this.CategoryName = categoryName;
            this.Input = input;
            this.Categories = categories;
            this.Count = count;
        }
    }
}