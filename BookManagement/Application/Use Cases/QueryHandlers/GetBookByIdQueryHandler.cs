using Application.Use_Cases.Queries;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using AutoMapper;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private IMapper mapper;
        private IBookRepository repository;

        public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);
            //return new BookDto
            //{
            //    Id = book.Id,
            //    Title = book.Title,
            //    Author = book.Author,
            //    ISBN = book.ISBN,
            //    PublicationDate = book.PublicationDate
            //};
            return mapper.Map<BookDto>(book);
        }
    }
}
