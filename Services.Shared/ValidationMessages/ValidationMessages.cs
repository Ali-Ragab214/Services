﻿using static Services.Shared.ValidationMessages.ValidationMessages;

namespace Services.Shared.ValidationMessages
{
    public class ValidationMessages
    {
        public const string Success = "operation done successfully";
        public const string Falier = "operation not successfully";

        public static class Users
        {
            public const string NameIsRequired = "Name Is Required.";
            public const string UserTypeIsRequired = "Type Is Required.";
            public const string PhoneIsRequired = "Phone Is Required.";
            public const string IdIsRequired = "Id Is Required.";
            public const string EmailIsRequired = "Email Is Required.";
            public const string EmailOrPhoneIsRequired = "Email Or Phone Is Required.";
            public const string PasswordIsRequired = "Password Is Required.";
            public const string ConfirmPasswordIsRequired = "ConfirmPassword Is Required.";
            public const string ComparePassword = "ConfirmPassword Not Equal Password.";
            public const string EmailIsExist = "Email Is Exist.";
            public const string EmailIsNotExist = "Email Is Not Exist.";
            public const string ValidMail = "Make Sure This Email is Valid.";
            public const string PhoneNumberNotValid = "Phone Number Not Valid.";
            public const string UserNotExist = "User Not Exist.";
            public const string ConfirmEmail = "Write this Code Correct that Confirm Email.";
            public const string ValidatePhoneNumber = "Phone Number Invalid.";
            public const string EmailOrPhoneNumberNotExist = "Email Or PhoneNumber Not Exist.";
            public const string IncorrectPassword = "Incorrect Password.";
            public const string LogoutError = "Invalid Token.";
            public const string VerifyCode = "Code Incorrect.";
            public const string ResetPassword = "Reset Password Code.";
            public const string EmailNotConfirmed = "Email Not Confirmed.";
            public const string MakeSureInformation = "Make Sure Information.";
            public const string MinLength = "Password must be at least 8 characters long.";
            public const string MaxLength = "Password must be at most 20 characters long.";
            public const string NotFount = "Email or Password not correct.";
            public const string RoleIdIsRequired = "Role Id Is Required.";
            public const string PermissionIdIsRequired = "Permission Id Is Required.";
            public static string RoleNotExist = "Role Is Not Exist.";
            public static string PermissionNotExist = "Permission Is Not Exist.";
            public static string PermissionAlreadyAssignToRole =
                "Permission Already Assign To Role.";
        }

        public static class Database
        {
            public const string Error = "Occur Exception By Transaction.";
        }

        public static class Workers
        {
            public const string WorkereNotExist = "Worker Not Exist.";
        }

        public static class Customers
        {
            public const string CustomerNotExist = "Customer Not Exist.";
        }

        public static class Service
        {
            public const string NameIsRequired = "Name Is Required.";
            public const string NameIsExist = "Name Is Exist.";
            public const string DescriptionIsRequired = "Description Is Required.";
            public const string ImageIsRequired = "Image Is Required.";
            public const string IdIsRequired = "Id Is Required.";
            public const string ServiceNotExist = "Service Not Exist.";
            public const string RateIsRequired = "Rate Is Required.";
        }

        public static class WorkereService
        {
            public const string WorkerIdIsRequired = "Worker Id Is Required.";
            public const string BranchIdIsRequired = "Branch Id Is Required.";
            public const string ServiceIdIsRequired = "Service Id Is Required.";
            public const string ServiceNotExist = "Service Not Exist.";
            public const string WorkerNotExist = "Worker Not Exist.";
            public const string AssignWorkerToService = "Assign Worker To Service Exist.";
            public const string WorkerNotAssignToService = "Worker Not Assign To Service.";
            public const string BranchNotExist = "Branch Not Exist.";
            public const string NotFound = "Not Found Workers.";
        }

        public static class Branchs
        {
            public const string NameIsRequired = "Name Is Required.";
            public const string IdIsRequired = "Id Is Required";
            public const string IdIsNotFound = "Id Is Not Found";
            public const string Langtuide = "Langtuide is required";
            public const string Latitude = "Latitude is required";
            public const string NameIsExist = "Name Is Exist.";
            public const string DescriptionIsRequired = "Description Is Required.";
            public const string BranchNotExist = "Branch Not Exist.";
        }

        public static class Category
        {
            public const string IdIsRequired = "Id Is Required";
            public const string CategoryNotExist = "Category Not Exist.";
            public const string CategoryExist = "Category Is Exist.";
            public const string CategoryIdIsRequired = "Category Id Is Required.";
            public const string NameIsRequired = "Name Is Required.";
            public const string DescriptionIsRequired = "Description Is Required.";
        }

        public static class Booking
        {
            public const string IdIsRequired = "Id Is Required";
            public const string WorkerIdIsRequired = "Worker Id Is Required.";
            public const string CustomerIdIsRequired = "Customer Id Is Required.";
            public const string LocationIsRequired = "Location Is Required.";
            public const string BookingNotExist = "Booking Not Exist.";
            public const string UserNotFound = "User Not Found.";
            public const string RateNotExist =
                "You can’t book a new service until you rate the last one.";
        }

        public static class Discount
        {
            public const string IdIsRequired = "Id Is Required.";
            public const string PercentageIsRequired = "Percentage Is Required.";
            public const string ExpireDateIsRequired = "Expire Date IsRequired.";
            public const string DiscountIsExist = "Discount Is Exist.";
            public const string DiscountNotExist = "Discount Not Exist.";
        }

        public static class DiscountRule
        {
            public const string DiscountIdIsRequired = "DiscountIdId Is Required.";
            public const string MainPointIsRequired = "MainPoint Is Required.";
            public const string MainPointIsExist = "MainPoint Is Already Exist.";
            public const string IdIsNotIsExist = "ID Is Not Exist.";
        }
    }
}
