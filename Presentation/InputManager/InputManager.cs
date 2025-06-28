using System;

namespace Presentation
{
    /// <summary>
    /// Klasa zadužena za prikupljanje korisničkog unosa.
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// Prikazuje prompt i čita unos sa konzole.
        /// </summary>
        /// <param name="prompt">Poruka koja se prikazuje korisniku.</param>
        /// <returns>Uneta vrednost kao string.</returns>
        public string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
