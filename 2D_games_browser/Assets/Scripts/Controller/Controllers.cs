using System.Collections.Generic;
using Interface;

namespace Controller
{
    public sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup
    {
        private readonly List<IInitialization> _initializationsControllers;
        private readonly List<IExecute> _executesControllers;
        private readonly List<ILateExecute> _lateExecutesControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializationController)
            {
                _initializationsControllers.Add(initializationController);
            }

            if (controller is IExecute executeController)
            {
                _executesControllers.Add(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateExecutesControllers.Add(lateExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        internal Controllers()
        {
            _initializationsControllers = new List<IInitialization>();
            _executesControllers = new List<IExecute>();
            _lateExecutesControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }
        public void Initialization()
        {
            foreach (var item in _initializationsControllers)
            {
                item.Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var item in _executesControllers)
            {
                item.Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            foreach (var item in _lateExecutesControllers)
            {
                item.LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            foreach (var item in _cleanupControllers)
            {
                item.Cleanup();
            }
        }
    }
}