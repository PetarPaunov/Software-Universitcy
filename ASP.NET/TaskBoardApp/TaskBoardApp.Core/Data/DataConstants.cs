namespace TaskBoardApp.Core.Data
{
    public class DataConstants
    {
        public class ApplicationUser
        {
            public const int FirstNameMaxLength = 15;
            public const int LastNameMaxLength = 15;
        }

        public class Task
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public class Board
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }
    }
}