namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    this.Add(ContentType.Book, command, contentCatalog, output);
                    break;
                case CommandType.AddMovie:
                    this.Add(ContentType.Movie, command, contentCatalog, output);
                    break;
                case CommandType.AddSong:
                    this.Add(ContentType.Song, command, contentCatalog, output);
                    break;
                case CommandType.AddApplication:
                    this.Add(ContentType.Application, command, contentCatalog, output);
                    break;
                case CommandType.Update:
                    this.Update(command, contentCatalog, output);
                    break;
                case CommandType.Find:
                    this.Find(command, contentCatalog, output);
                    break;
                default:
                    throw new ArgumentException("Unknown command!");
            }
        }
        
        private void Add(ContentType contentType, ICommand command, ICatalog contentCatalog, StringBuilder output)
        {
            IContent currentBook = new Content(contentType, command.Parameters);
            contentCatalog.Add(currentBook);
            output.AppendLine(contentType + " added");
        }

        private void Update(ICommand command, ICatalog contentCatalog, StringBuilder output)
        {
            int numberOfUpdatedItems = contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            string outputString = string.Format("{0} items updated", numberOfUpdatedItems);
            output.AppendLine(outputString);
        }

        private void Find(ICommand command, ICatalog contentCatalog, StringBuilder output)
        {
            int numberOfElementsToList = int.Parse(command.Parameters[1]);
            IEnumerable<IContent> foundContent = contentCatalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}