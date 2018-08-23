using GradeBook.Enums;


namespace GradeBook.GradeBooks
{
    class StandardGradebook : BaseGradeBook
    {
        public StandardGradebook(string name) : base(name)
        {
            Type = GradebookType.Standard;
                    //Create a constructor for the StandardGradeBook class that accepts a string parameter called "name". This constructor is required to invoke a constructor from BaseGradeBook.This can be done by adding : base(name) after the constructor declaration. (this will make it so when the StandardGradeBook constructor is called it will execute code in both StandardGradeBook's constructor as well as the BaseGradeBook's constructor)
        }
    }
}
