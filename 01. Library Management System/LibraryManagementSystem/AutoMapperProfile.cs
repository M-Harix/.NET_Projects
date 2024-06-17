using AutoMapper;
using LibraryManagementSystem.Dto;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<BookCopy, BookCopyDto>();
            CreateMap<BookCopyDto, BookCopy>();

            CreateMap<Borrowing, BorrowingDto>();
            CreateMap<BorrowingDto, Borrowing>();

            CreateMap<Fine, FineDto>();
            CreateMap<FineDto, Fine>();

            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();

            CreateMap<Publisher, PublisherDto>();
            CreateMap<PublisherDto, Publisher>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
