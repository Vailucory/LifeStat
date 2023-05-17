namespace LifeStat.Application.Validators;
public static class ValidatorsConstants
{
    public const string USERNAME_REGEX = "^[a-zA-Z0-9-_]+$";

    public const string PASSWORD_REGEX = @"^[a-zA-Z0-9!@#$%^&*()_+\-=[\]{};':\\|,.<>/?]*$";

    public const int USERNAME_MIN_LENGTH = 2;

    public const int USERNAME_MAX_LENGTH = 20;
    
    public const int PASSWORD_MIN_LENGTH = 6;

    public const int PASSWORD_MAX_LENGTH = 32;

    public const int DAILY_PLAN_TEMPLATE_NAME_MIN_LENGTH = 2;

    public const int DAILY_PLAN_TEMPLATE_NAME_MAX_LENGTH = 32;

    public const int WEEKLY_PLAN_TEMPLATE_NAME_MIN_LENGTH = 2;

    public const int WEEKLY_PLAN_TEMPLATE_NAME_MAX_LENGTH = 32;

    public const int ACTIVITY_TEMPLATE_NAME_MIN_LENGTH = 2;

    public const int ACTIVITY_TEMPLATE_NAME_MAX_LENGTH = 32;
}
