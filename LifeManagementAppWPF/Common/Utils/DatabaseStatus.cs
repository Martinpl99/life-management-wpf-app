using CommunityToolkit.Mvvm.ComponentModel;
using LifeManagementAppWPF.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Common.Utils
{
    /// <summary>
    /// Progress ring data provider
    /// </summary>
    public class DatabaseStatus : ObservableObject, IDatabaseStatus
    {
        private bool _databaseOperationIsPerforming = true;
        public bool DatabaseOperationIsPerforming 
        {
            get => _databaseOperationIsPerforming;
            set => SetProperty(ref _databaseOperationIsPerforming, value);
        }
        public void StartDatabaseOperation()
        {
            DatabaseOperationIsPerforming = true;
        }

        public void EndDatabaseOperation()
        {
            DatabaseOperationIsPerforming = false;
        }
    }
}
