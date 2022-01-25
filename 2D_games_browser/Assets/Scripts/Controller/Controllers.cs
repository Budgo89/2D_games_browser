using System;
using System.Collections.Generic;
using Interface;

namespace Controller
{
    public sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup, IFixed, IAwakeExecute
    {
        private readonly List<IInitialization> _initializationsControllers;
        private readonly List<IExecute> _executesControllers;
        private readonly List<ILateExecute> _lateExecutesControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private readonly List<IAwakeExecute> _awakeControllers;
        private readonly List<IFixed> _fixedExecutesControllers;

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
            if(controller is IFixed fixedController)
            {
                _fixedExecutesControllers.Add(fixedController);
            }
            if(controller is IAwakeExecute awakeExecute)
            {
                _awakeControllers.Add(awakeExecute);
            }

            return this;
        }

        internal Controllers()
        {
            _initializationsControllers = new List<IInitialization>();
            _executesControllers = new List<IExecute>();
            _lateExecutesControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
            _fixedExecutesControllers = new List<IFixed>();
            _awakeControllers = new List<IAwakeExecute>();
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

        public void FixedExecute()
        {
            foreach (var item in _fixedExecutesControllers)
            {
                item.FixedExecute();
            }
        }
        public void AwakeExecute()
        {
            foreach (var item in _awakeControllers)
            {
                item.AwakeExecute();
            }
        }
    }
}