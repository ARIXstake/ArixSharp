using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Arix.Contracts.Arix.ContractDefinition;

namespace Arix.Contracts.Arix
{
    public partial class ArixService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ArixDeployment arixDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ArixDeployment>().SendRequestAndWaitForReceiptAsync(arixDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ArixDeployment arixDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ArixDeployment>().SendRequestAsync(arixDeployment);
        }

        public static async Task<ArixService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ArixDeployment arixDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, arixDeployment, cancellationTokenSource);
            return new ArixService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ArixService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> RewardCoefficientsOfQueryAsync(RewardCoefficientsOfFunction rewardCoefficientsOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RewardCoefficientsOfFunction, BigInteger>(rewardCoefficientsOfFunction, blockParameter);
        }

        
        public Task<BigInteger> RewardCoefficientsOfQueryAsync(string stakeAddress, BigInteger stakeStartTime, BigInteger rewardTime, BlockParameter blockParameter = null)
        {
            var rewardCoefficientsOfFunction = new RewardCoefficientsOfFunction();
                rewardCoefficientsOfFunction.StakeAddress = stakeAddress;
                rewardCoefficientsOfFunction.StakeStartTime = stakeStartTime;
                rewardCoefficientsOfFunction.RewardTime = rewardTime;
 
            return ContractHandler.QueryAsync<RewardCoefficientsOfFunction, BigInteger>(rewardCoefficientsOfFunction, blockParameter);
        }

        public Task<BigInteger> RewardTimesOfQueryAsync(RewardTimesOfFunction rewardTimesOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RewardTimesOfFunction, BigInteger>(rewardTimesOfFunction, blockParameter);
        }

        
        public Task<BigInteger> RewardTimesOfQueryAsync(string stakeAddress, BigInteger stakeStartTime, BigInteger index, BlockParameter blockParameter = null)
        {
            var rewardTimesOfFunction = new RewardTimesOfFunction();
                rewardTimesOfFunction.StakeAddress = stakeAddress;
                rewardTimesOfFunction.StakeStartTime = stakeStartTime;
                rewardTimesOfFunction.Index = index;
            
            return ContractHandler.QueryAsync<RewardTimesOfFunction, BigInteger>(rewardTimesOfFunction, blockParameter);
        }

        public Task<BigInteger> RewardValuesOfQueryAsync(RewardValuesOfFunction rewardValuesOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RewardValuesOfFunction, BigInteger>(rewardValuesOfFunction, blockParameter);
        }

        
        public Task<BigInteger> RewardValuesOfQueryAsync(string stakeAddress, BigInteger stakeStartTime, BigInteger rewardTime, BlockParameter blockParameter = null)
        {
            var rewardValuesOfFunction = new RewardValuesOfFunction();
                rewardValuesOfFunction.StakeAddress = stakeAddress;
                rewardValuesOfFunction.StakeStartTime = stakeStartTime;
                rewardValuesOfFunction.RewardTime = rewardTime;
            
            return ContractHandler.QueryAsync<RewardValuesOfFunction, BigInteger>(rewardValuesOfFunction, blockParameter);
        }

        public Task<string> RewardPayRequestAsync(RewardPayFunction rewardPayFunction)
        {
             return ContractHandler.SendRequestAsync(rewardPayFunction);
        }

        public Task<TransactionReceipt> RewardPayRequestAndWaitForReceiptAsync(RewardPayFunction rewardPayFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rewardPayFunction, cancellationToken);
        }

        public Task<string> RewardPayRequestAsync(string stakeAddress, BigInteger stakeStartTime, BigInteger rewardTime)
        {
            var rewardPayFunction = new RewardPayFunction();
                rewardPayFunction.StakeAddress = stakeAddress;
                rewardPayFunction.StakeStartTime = stakeStartTime;
                rewardPayFunction.RewardTime = rewardTime;
            
             return ContractHandler.SendRequestAsync(rewardPayFunction);
        }

        public Task<TransactionReceipt> RewardPayRequestAndWaitForReceiptAsync(string stakeAddress, BigInteger stakeStartTime, BigInteger rewardTime, CancellationTokenSource cancellationToken = null)
        {
            var rewardPayFunction = new RewardPayFunction();
                rewardPayFunction.StakeAddress = stakeAddress;
                rewardPayFunction.StakeStartTime = stakeStartTime;
                rewardPayFunction.RewardTime = rewardTime;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rewardPayFunction, cancellationToken);
        }

        public Task<string> RemoveFreezRequestAsync(RemoveFreezFunction removeFreezFunction)
        {
             return ContractHandler.SendRequestAsync(removeFreezFunction);
        }

        public Task<TransactionReceipt> RemoveFreezRequestAndWaitForReceiptAsync(RemoveFreezFunction removeFreezFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeFreezFunction, cancellationToken);
        }

        public Task<string> RemoveFreezRequestAsync(string stakeAddress, BigInteger index)
        {
            var removeFreezFunction = new RemoveFreezFunction();
                removeFreezFunction.StakeAddress = stakeAddress;
                removeFreezFunction.Index = index;
            
             return ContractHandler.SendRequestAsync(removeFreezFunction);
        }

        public Task<TransactionReceipt> RemoveFreezRequestAndWaitForReceiptAsync(string stakeAddress, BigInteger index, CancellationTokenSource cancellationToken = null)
        {
            var removeFreezFunction = new RemoveFreezFunction();
                removeFreezFunction.StakeAddress = stakeAddress;
                removeFreezFunction.Index = index;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeFreezFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string sender, string recipient, BigInteger amount)
        {
            var transferFunction = new TransferFunction();
                transferFunction.Sender = sender;
                transferFunction.Recipient = recipient;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string sender, string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.Sender = sender;
                transferFunction.Recipient = recipient;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Owner = owner;
                allowanceFunction.Spender = spender;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger amount)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> ContractOfQueryAsync(ContractOfFunction contractOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractOfFunction, string>(contractOfFunction, blockParameter);
        }

        
        public Task<string> ContractOfQueryAsync(string account, BigInteger stakeTime, BlockParameter blockParameter = null)
        {
            var contractOfFunction = new ContractOfFunction();
                contractOfFunction.Account = account;
                contractOfFunction.StakeTime = stakeTime;
            
            return ContractHandler.QueryAsync<ContractOfFunction, string>(contractOfFunction, blockParameter);
        }

        public Task<BigInteger> CurrentTimeOfQueryAsync(CurrentTimeOfFunction currentTimeOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentTimeOfFunction, BigInteger>(currentTimeOfFunction, blockParameter);
        }

        
        public Task<BigInteger> CurrentTimeOfQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentTimeOfFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> DecreaseAllowanceRequestAsync(DecreaseAllowanceFunction decreaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(DecreaseAllowanceFunction decreaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
        }

        public Task<string> DecreaseAllowanceRequestAsync(string spender, BigInteger subtractedValue)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
        }

        public Task<BigInteger> DeployTimeOfQueryAsync(DeployTimeOfFunction deployTimeOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DeployTimeOfFunction, BigInteger>(deployTimeOfFunction, blockParameter);
        }

        
        public Task<BigInteger> DeployTimeOfQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DeployTimeOfFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> FreezOfQueryAsync(FreezOfFunction freezOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreezOfFunction, BigInteger>(freezOfFunction, blockParameter);
        }

        
        public Task<BigInteger> FreezOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var freezOfFunction = new FreezOfFunction();
                freezOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<FreezOfFunction, BigInteger>(freezOfFunction, blockParameter);
        }

        public Task<string> IncreaseAllowanceRequestAsync(IncreaseAllowanceFunction increaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(IncreaseAllowanceFunction increaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> IncreaseAllowanceRequestAsync(string spender, BigInteger addedValue)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> PayedOfQueryAsync(PayedOfFunction payedOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PayedOfFunction, BigInteger>(payedOfFunction, blockParameter);
        }

        
        public Task<BigInteger> PayedOfQueryAsync(string account, BigInteger stakeTime, BigInteger rewardTime, BlockParameter blockParameter = null)
        {
            var payedOfFunction = new PayedOfFunction();
                payedOfFunction.Account = account;
                payedOfFunction.StakeTime = stakeTime;
                payedOfFunction.RewardTime = rewardTime;
            
            return ContractHandler.QueryAsync<PayedOfFunction, BigInteger>(payedOfFunction, blockParameter);
        }

        public Task<string> StakeRequestAsync(StakeFunction stakeFunction)
        {
             return ContractHandler.SendRequestAsync(stakeFunction);
        }

        public Task<TransactionReceipt> StakeRequestAndWaitForReceiptAsync(StakeFunction stakeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeFunction, cancellationToken);
        }

        public Task<string> StakeRequestAsync(BigInteger amount, string stakeAddress, BigInteger index)
        {
            var stakeFunction = new StakeFunction();
                stakeFunction.Amount = amount;
                stakeFunction.StakeAddress = stakeAddress;
                stakeFunction.Index = index;
            
             return ContractHandler.SendRequestAsync(stakeFunction);
        }

        public Task<TransactionReceipt> StakeRequestAndWaitForReceiptAsync(BigInteger amount, string stakeAddress, BigInteger index, CancellationTokenSource cancellationToken = null)
        {
            var stakeFunction = new StakeFunction();
                stakeFunction.Amount = amount;
                stakeFunction.StakeAddress = stakeAddress;
                stakeFunction.Index = index;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeFunction, cancellationToken);
        }

        public Task<BigInteger> StakedateOfQueryAsync(StakedateOfFunction stakedateOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakedateOfFunction, BigInteger>(stakedateOfFunction, blockParameter);
        }

        
        public Task<BigInteger> StakedateOfQueryAsync(string account, BigInteger index, BlockParameter blockParameter = null)
        {
            var stakedateOfFunction = new StakedateOfFunction();
                stakedateOfFunction.Account = account;
                stakedateOfFunction.Index = index;
            
            return ContractHandler.QueryAsync<StakedateOfFunction, BigInteger>(stakedateOfFunction, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

    

        public Task<string> TransferRequestAsync(string recipient, BigInteger amount)
        {
            var transferFunction = new TransferFunction();
                transferFunction.Recipient = recipient;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.Recipient = recipient;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string sender, string recipient, BigInteger amount)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.Sender = sender;
                transferFromFunction.Recipient = recipient;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string sender, string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.Sender = sender;
                transferFromFunction.Recipient = recipient;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }
    }
}
