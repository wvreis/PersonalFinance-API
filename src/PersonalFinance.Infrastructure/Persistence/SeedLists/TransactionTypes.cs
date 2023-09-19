using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Enums;

namespace PersonalFinance.Infrastructure.Persistence.SeedLists;
public class TransactionTypes {
    public static List<TransactionType> GetAll()
    {
        return new() {
            new TransactionType(description: "Aluguel", transactionTypeGroupId: 1, nature: TransactionNature.Outbound),
            new TransactionType(description: "Conta de Luz", transactionTypeGroupId: 1, nature: TransactionNature.Outbound),
            new TransactionType(description: "Conta de Água", transactionTypeGroupId: 1, nature: TransactionNature.Outbound),
            new TransactionType(description: "Supermercado", transactionTypeGroupId: 2, nature: TransactionNature.Outbound),
            new TransactionType(description: "Restaurante", transactionTypeGroupId: 2, nature: TransactionNature.Outbound),
            new TransactionType(description: "Combustível", transactionTypeGroupId: 3, nature: TransactionNature.Outbound),
            new TransactionType(description: "Transporte Público", transactionTypeGroupId: 3, nature: TransactionNature.Outbound),
            new TransactionType(description: "Plano de Saúde", transactionTypeGroupId: 4, nature: TransactionNature.Outbound),
            new TransactionType(description: "Medicamentos", transactionTypeGroupId: 4, nature: TransactionNature.Outbound),
            new TransactionType(description: "Mensalidade Escolar", transactionTypeGroupId: 5, nature: TransactionNature.Outbound),
            new TransactionType(description: "Material Didático", transactionTypeGroupId: 5, nature: TransactionNature.Outbound),
            new TransactionType(description: "Cinema e Entretenimento", transactionTypeGroupId: 6, nature: TransactionNature.Outbound),
            new TransactionType(description: "Viagens", transactionTypeGroupId: 6, nature: TransactionNature.Outbound),
            new TransactionType(description: "Roupas", transactionTypeGroupId: 7, nature: TransactionNature.Outbound),
            new TransactionType(description: "Acessórios Pessoais", transactionTypeGroupId: 7, nature: TransactionNature.Outbound),
            new TransactionType(description: "Taxas Bancárias", transactionTypeGroupId: 8, nature: TransactionNature.Outbound),
            new TransactionType(description: "Juros e Empréstimos", transactionTypeGroupId: 8, nature: TransactionNature.Outbound),
            new TransactionType(description: "Imposto de Renda", transactionTypeGroupId: 9, nature: TransactionNature.Outbound),
            new TransactionType(description: "IPTU", transactionTypeGroupId: 9, nature: TransactionNature.Outbound),
            new TransactionType(description: "IPVA", transactionTypeGroupId: 9, nature: TransactionNature.Outbound),
            new TransactionType(description: "Doações", transactionTypeGroupId: 10, nature: TransactionNature.Outbound),
            new TransactionType(description: "Investimento em Ações", transactionTypeGroupId: 11, nature: TransactionNature.Outbound),
            new TransactionType(description: "Investimento em Fundos", transactionTypeGroupId: 11, nature: TransactionNature.Outbound),
            new TransactionType(description: "Seguro de Vida", transactionTypeGroupId: 12, nature: TransactionNature.Outbound),
            new TransactionType(description: "Seguro Residencial", transactionTypeGroupId: 12, nature: TransactionNature.Outbound),
            new TransactionType(description: "Seguro de Carro", transactionTypeGroupId: 12, nature: TransactionNature.Outbound),
            new TransactionType(description: "Salário", transactionTypeGroupId: 13, nature: TransactionNature.Inbound),
            new TransactionType(description: "Reembolso", transactionTypeGroupId: 13, nature: TransactionNature.Inbound),
            new TransactionType(description: "Venda de Produtos", transactionTypeGroupId: 13, nature: TransactionNature.Inbound),
            new TransactionType(description: "Investimento Recebido", transactionTypeGroupId: 13, nature: TransactionNature.Inbound),
            new TransactionType(description: "Pagamento de Dívida Recebido", transactionTypeGroupId: 13, nature: TransactionNature.Inbound),
        };
    }
}
