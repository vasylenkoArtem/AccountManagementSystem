using AMS.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public class UserBuilderDirector
    {
        private IUserBuilder _userBuilder;

        public IUserBuilder Builder
        {
            set { _userBuilder = value; }
        }

        public void BuildUser(int userTypeId)
        {
            //general user parts
            _userBuilder.CreateUserObject();
            _userBuilder.BuildPersonalInfo();

            switch (userTypeId)
            {
                case (int)UserType.Guest:
                    BuildGuestUser();
                    break;

                case (int)UserType.Student:
                    BuildStudentUser();
                    break;

                case (int)UserType.Engineer:
                    BuildEngineerUser();
                    break;

                default:
                    throw new Exception("Incorrect user type");
            }
        }

        private void BuildGuestUser()
        {
            _userBuilder.BuildComputers();
            _userBuilder.BuildIoTStaff();
        }

        private void BuildStudentUser()
        {
            _userBuilder.BuildPrinters();
            _userBuilder.BuildIoTStaff();
        }

        private void BuildEngineerUser()
        {
            _userBuilder.BuildComputers();
        }
    }
}
