using AMS.Domain.Computer;
using AMS.Domain.IoT;
using AMS.Domain.User;
using AMS.Logic.Constants;
using AMS.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainUserPrinter = AMS.Domain.Printer.UserPrinter;

namespace AMS.Logic.Services
{

    public interface IUserBuilder
    {
        void CreateUserObject();

        void BuildPersonalInfo();

        void BuildPrinters();

        void BuildComputers();

        void BuildIoTStaff();

        User GetResult();

    }

    public class UserBuilderParams
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public string IdentityLockUserId { get; set; }
        public List<int> PrinterIds { get; set; }
        public int ComputerId { get; set; }
        public List<string> AllowedPlasticTypes { get; set; }
        public int AllowedPlasticQuantity { get; set; }
        public int UserId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }


    public class UserBuilder : IUserBuilder
    {
        private User User { get; set; }

        private UserBuilderParams BuilderParams { get; set; }

        public UserBuilder(UserBuilderParams builderParams)
        {
            BuilderParams = builderParams;
        }

        public void CreateUserObject()
        {
            this.User = new User();
        }

        public void BuildPersonalInfo()
        {
            this.User.FirstName = BuilderParams.FirstName;
            this.User.LastName = BuilderParams.LastName;
            this.User.Email = BuilderParams.Email;
            this.User.UserTypeId = BuilderParams.UserTypeId;
            this.User.IdentityLockUserId = BuilderParams.IdentityLockUserId;
        }

        public void BuildPrinters()
        {
            //TODO: get with repo

            var ids = BuilderParams.PrinterIds;
            var printersToUse = new List<Domain.Printer.UserPrinter>();

            var plasticTypes = GetAllowedPlasticTypes();
            var plasticQuantity = GetAllowedPlasticQuantity();

            foreach (var printer in printersToUse)
            {
                this.User.UserPrinters.Add(new DomainUserPrinter(printer.Id, plasticTypes, plasticQuantity));
            }
        }

        public void BuildComputers()
        {
            //TODO: get with repo, get by id 
            var id = BuilderParams.ComputerId;
            var computerToUse = new Computer();

            var validityDates = GetComputerUseValidityDates();

            var userComputer = new UserComputer(computerToUse.Id, BuilderParams.UserId, validityDates.Item1, validityDates.Item2);

            this.User.Computers.Add(userComputer);
        }

        public void BuildIoTStaff()
        {
            var ioTComponents = GetIoTComponentsForSet();
            var ioTSetName = GetIoTSetName();

            var ioTSet = new IoTSet(ioTSetName, BuilderParams.UserId, DateTime.Now);

            foreach (var component in ioTComponents)
            {
                var ioTSetComponent = new IoTSetComponent
                {
                    Component = component
                };

                ioTSet.Components.Add(ioTSetComponent);
            }
        }

        private List<IoTComponent> GetIoTComponentsForSet()
        {
            /*
             for student:
              replace with query to find base iotComponents ->
              Get 2 arduino uno iotComponents
              Get 1 arduino nano iotComponent
              Get base list of components (sensors, wires..)

             for guest:
                Get top(1) arduino uno iotComponents
                Get minimal list of components (sensors, wires..)
             */


            return new List<IoTComponent>();
        }

        private string GetIoTSetName()
        {
            switch (BuilderParams.UserTypeId)
            {
                case (int)UserType.Student:
                    return $"Base set for UserId: {BuilderParams.UserId}";
                case (int)UserType.Guest:
                    return $"Minimal set for UserId: {BuilderParams.UserId}";

                default:
                    return "";
            }

        }

        public User GetResult() => this.User;

        private List<string> GetAllowedPlasticTypes()
        {
            var userTypeId = BuilderParams.UserTypeId;

            switch (userTypeId)
            {
                case (int)UserType.Student:
                    return UserBuilderConstants.AllowedPlasticTypesForStudent.ToList();
                case (int)UserType.Engineer:
                    return null;

                default:
                    return null;
            }
        }

        private int? GetAllowedPlasticQuantity()
        {
            var userTypeId = BuilderParams.UserTypeId;

            switch (userTypeId)
            {
                case (int)UserType.Student:
                    return UserBuilderConstants.AllowedPlasticQuantityForStudent;

                default:
                    return null;
            }
        }

        private (DateTime?, DateTime?) GetComputerUseValidityDates()
        {
            var userTypeId = BuilderParams.UserTypeId;

            switch (userTypeId)
            {
                case (int)UserType.Guest:
                    return UserBuilderConstants.ComputerUseValidityDatesForGuest;
                case (int)UserType.Engineer:
                    //infinite amount of days
                    return (null, null);

                default:
                    return (null, null);
            }
        }
    }
}
