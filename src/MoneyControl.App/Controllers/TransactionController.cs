using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.App.DTOs;
using MoneyControl.Business.Interfaces;
using MoneyControl.Business.Interfaces.Repository;
using MoneyControl.Business.Models;

namespace MoneyControl.App.Controllers;

[Route("api/transaction")]
public class TransactionController : MainController
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionService _transactionService;

    private readonly IMapper _mapper;

    public TransactionController(
        INotifier notifier,
        ITransactionRepository transactionRepository,
        ITransactionService transactionService,
        IMapper mapper) : base(notifier)
    {
        _transactionRepository = transactionRepository;
        _transactionService = transactionService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TransactionDTO>> Get(Guid id)
    {
        var transactionDTO = _mapper.Map<TransactionDTO>(await _transactionRepository.GetById(id));

        return Ok(transactionDTO);
    }

    [HttpGet("get-transactions/")]
    public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAll()
    {
        var transactionsDTO = _mapper.Map<IEnumerable<Transaction>>(await _transactionRepository.GetAll());

        return CustomResponse(transactionsDTO);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionDTO>> Add(TransactionDTO transactionDTO)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        var transaction = await _transactionService.Add(_mapper.Map<Transaction>(transactionDTO));

        if (transaction != null)
            transactionDTO.Id = transaction.Id;

        return CustomResponse(transactionDTO);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TransactionDTO>> Update(Guid id, TransactionDTO transactionDTO)
    {
        if (id != transactionDTO.Id)
        {
            NotifyErrors("ID inválido!");
            return CustomResponse(transactionDTO);
        }

        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        await _transactionService.Update(_mapper.Map<Transaction>(transactionDTO));

        return CustomResponse(transactionDTO);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<TransactionDTO>> Remove(Guid id)
    {
        var transactionDTO = _mapper.Map<TransactionDTO>(await _transactionRepository.GetById(id));

        if (transactionDTO == null)
            return NotFound();

        await _transactionService.Remove(id);

        return CustomResponse(transactionDTO);
    }


    [HttpGet("{q:string}")]
    public async Task<ActionResult<TransactionDTO>> Query(string q)
    {
        var transactionDTO = _mapper.Map<TransactionDTO>(await _transactionRepository.Get(t => t.Description.Contains(q)));

        return Ok(transactionDTO);
    }
}
