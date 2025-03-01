using ProSpaceTestTask.DTOs;

namespace ProSpaceTestTask.MediatR.GetAllUsers;

public record GetAllUsersResponse(List<GetAllUsersDto> Users);