using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Arix.Contracts.Arix.ContractDefinition
{

    public partial class ArixDeployment : ArixDeploymentBase
    {
        public ArixDeployment() : base(BYTECODE) { }
        public ArixDeployment(string byteCode) : base(byteCode) { }
    }

    public class ArixDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public ArixDeploymentBase() : base(BYTECODE) { }
        public ArixDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "initialSupply", 1)]
        public virtual BigInteger InitialSupply { get; set; }
    }

    public partial class RewardCoefficientsOfFunction : RewardCoefficientsOfFunctionBase { }

    [Function("RewardCoefficientsOf", "uint256")]
    public class RewardCoefficientsOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_stakeAddress", 1)]
        public virtual string StakeAddress { get; set; }
        [Parameter("uint256", "_stakeStartTime", 2)]
        public virtual BigInteger StakeStartTime { get; set; }
        [Parameter("uint256", "_rewardTime", 3)]
        public virtual BigInteger RewardTime { get; set; }
    }

    public partial class RewardTimesOfFunction : RewardTimesOfFunctionBase { }

    [Function("RewardTimesOf", "uint256")]
    public class RewardTimesOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_stakeAddress", 1)]
        public virtual string StakeAddress { get; set; }
        [Parameter("uint256", "_stakeStartTime", 2)]
        public virtual BigInteger StakeStartTime { get; set; }
        [Parameter("uint256", "index", 3)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class RewardValuesOfFunction : RewardValuesOfFunctionBase { }

    [Function("RewardValuesOf", "uint256")]
    public class RewardValuesOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_stakeAddress", 1)]
        public virtual string StakeAddress { get; set; }
        [Parameter("uint256", "_stakeStartTime", 2)]
        public virtual BigInteger StakeStartTime { get; set; }
        [Parameter("uint256", "_rewardTime", 3)]
        public virtual BigInteger RewardTime { get; set; }
    }

    public partial class RewardPayFunction : RewardPayFunctionBase { }

    [Function("_RewardPay")]
    public class RewardPayFunctionBase : FunctionMessage
    {
        [Parameter("address", "_StakeAddress", 1)]
        public virtual string StakeAddress { get; set; }
        [Parameter("uint256", "_StakeStartTime", 2)]
        public virtual BigInteger StakeStartTime { get; set; }
        [Parameter("uint256", "_rewardTime", 3)]
        public virtual BigInteger RewardTime { get; set; }
    }

    public partial class RemoveFreezFunction : RemoveFreezFunctionBase { }

    [Function("_removeFreez")]
    public class RemoveFreezFunctionBase : FunctionMessage
    {
        [Parameter("address", "_stakeAddress", 1)]
        public virtual string StakeAddress { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("_transfer")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("address", "recipient", 2)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class ContractOfFunction : ContractOfFunctionBase { }

    [Function("contractOf", "string")]
    public class ContractOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "stakeTime", 2)]
        public virtual BigInteger StakeTime { get; set; }
    }

    public partial class CurrentTimeOfFunction : CurrentTimeOfFunctionBase { }

    [Function("currentTimeOf", "uint256")]
    public class CurrentTimeOfFunctionBase : FunctionMessage
    {

    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class DeployTimeOfFunction : DeployTimeOfFunctionBase { }

    [Function("deployTimeOf", "uint256")]
    public class DeployTimeOfFunctionBase : FunctionMessage
    {

    }

    public partial class FreezOfFunction : FreezOfFunctionBase { }

    [Function("freezOf", "uint256")]
    public class FreezOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class PayedOfFunction : PayedOfFunctionBase { }

    [Function("payedOf", "uint256")]
    public class PayedOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "stakeTime", 2)]
        public virtual BigInteger StakeTime { get; set; }
        [Parameter("uint256", "_rewardTime", 3)]
        public virtual BigInteger RewardTime { get; set; }
    }

    public partial class StakeFunction : StakeFunctionBase { }

    [Function("stake", "uint256")]
    public class StakeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "_stakeAddress", 2)]
        public virtual string StakeAddress { get; set; }
        [Parameter("uint256", "index", 3)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class StakedateOfFunction : StakedateOfFunctionBase { }

    [Function("stakedateOf", "uint256")]
    public class StakedateOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }


    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("address", "recipient", 2)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class StakeEventDTO : StakeEventDTOBase { }

    [Event("Stake")]
    public class StakeEventDTOBase : IEventDTO
    {
        [Parameter("address", "to", 1, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 2, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class RewardCoefficientsOfOutputDTO : RewardCoefficientsOfOutputDTOBase { }

    [FunctionOutput]
    public class RewardCoefficientsOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class RewardTimesOfOutputDTO : RewardTimesOfOutputDTOBase { }

    [FunctionOutput]
    public class RewardTimesOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class RewardValuesOfOutputDTO : RewardValuesOfOutputDTOBase { }

    [FunctionOutput]
    public class RewardValuesOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }







    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ContractOfOutputDTO : ContractOfOutputDTOBase { }

    [FunctionOutput]
    public class ContractOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CurrentTimeOfOutputDTO : CurrentTimeOfOutputDTOBase { }

    [FunctionOutput]
    public class CurrentTimeOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class DeployTimeOfOutputDTO : DeployTimeOfOutputDTOBase { }

    [FunctionOutput]
    public class DeployTimeOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class FreezOfOutputDTO : FreezOfOutputDTOBase { }

    [FunctionOutput]
    public class FreezOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PayedOfOutputDTO : PayedOfOutputDTOBase { }

    [FunctionOutput]
    public class PayedOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class StakedateOfOutputDTO : StakedateOfOutputDTOBase { }

    [FunctionOutput]
    public class StakedateOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }




}
