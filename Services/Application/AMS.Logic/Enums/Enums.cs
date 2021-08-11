using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Enums
{
    public enum UserType
    {
        Guest = 1,
        Student = 2,
        Engineer = 3
    }

    public enum MessengerType
    {
        Telegram = 1,
        Viber = 2,
        Email = 3
    }

    public enum ActionType
    {
        ManageUsers = 1,
        UnlockRoom = 2,
        Manage_3D_Printers = 3,
        Use_3D_Printers = 4,
        Issue_3D_Printers = 5,
        ManageRooms = 6,
        ManageUserRooms = 7,
        ManageComputers = 8,
        IssueComputers = 9,
        IssueIoTSets = 10,
        ManageIoTSets = 11

    }

}
