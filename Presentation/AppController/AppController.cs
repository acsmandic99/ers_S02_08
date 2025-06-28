using Domain.Models;
using Presentation;

namespace Presentation
{
    /// <summary>
    /// Kontroler aplikacije koji orkestrira kompletan tok korisničke interakcije.
    /// </summary>
    public class AppController
    {
        private readonly DisplayManager _displayManager;
        private readonly InputManager _inputManager;
        private readonly CommandHandler _commandHandler;
        private readonly Regulator _regulator;
        private readonly MenadzerTemperatura _tempManager;

        public AppController(DisplayManager displayManager, InputManager inputManager,
                             CommandHandler commandHandler, Regulator regulator, MenadzerTemperatura tempManager)
        {
            _displayManager = displayManager;
            _inputManager = inputManager;
            _commandHandler = commandHandler;
            _regulator = regulator;
            _tempManager = tempManager;
        }

        /// <summary>
        /// Pokreće glavni korisnički ciklus interakcije.
        /// </summary>
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                _displayManager.ShowHeader(_regulator);
                _displayManager.ShowMenu();
                string command = _inputManager.GetUserInput("Unesite opciju: ");
                _commandHandler.HandleCommand(command, _regulator, _tempManager);
                _displayManager.Pause();
            }
        }
    }
}