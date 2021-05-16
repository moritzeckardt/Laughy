using Laughy.Logic.Operation.LaughyManagement.Contracts;

namespace Laughy.Logic.Operation.LaughyManagement
{
    public class JokeManager : IJokeManager
    {
        //Methods
        public string TransormCategory(string category)
        {
            if(category.Contains("Any joke (recommended)"))
            {
                return "any";
            }

            else if(category.Contains("Favourite jokes"))
            {
                return "favourite";
            }

            else if (category.Contains("Own jokes"))
            {
                return "own";
            }

            else
            {
                return category;
            }      
        }
    }
}
