namespace ProgInt2.Contracts.Authentication;

public record ChangePasswordRequest(    
    string Id,
    string NewPassword
);