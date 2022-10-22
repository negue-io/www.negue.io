using Fluxor;

namespace NegueApp.Components.Terminal
{
    namespace NegueApp.Components.Terminal
    {
        public record TerminalStore
        {
            public bool IsSubmitting { get; init; }
            public object Model { get; init; }
        }


        public class MessagePromoCreationStoreFeature : Feature<TerminalStore>
        {
            public override string GetName() => "TerminalStore";

            protected override TerminalStore GetInitialState()
            {
                return new TerminalStore
                {
                    IsSubmitting = false,
                };
            }
        }


        public class TerminalStoreAction
        {
            public TerminalStoreAction()
            {
                
            }

            public object Model { get; }

        }

        public class TerminalStoreSuccessAction
        {
        }

        public class TerminalStoreFailureAction
        {
        }

        public static class TerminalStoreReducers
        {
            [ReducerMethod]
            public static TerminalStore OnMsgPromoCreationCreate(TerminalStore state, TerminalStoreAction action)
            {
                return state with
                {
                    IsSubmitting = true,
                    Model = action.Model
                };
            }

            [ReducerMethod]
            public static TerminalStore OnMsgPromoCreationSucess(TerminalStore state, TerminalStoreSuccessAction action)
            {
                return state with
                {
                    IsSubmitting = false
                };
            }

            [ReducerMethod]
            public static TerminalStore OnMsgPromoCreationFailure(TerminalStore state, TerminalStoreFailureAction action)
            {
                return state with
                {
                    IsSubmitting = false
                };
            }
        }

        public class MessagePromoCreationStoreEffects
        {
            public MessagePromoCreationStoreEffects()
            {
                
            }

            [EffectMethod]
            public async Task CreateMessagePromo(TerminalStoreAction action, IDispatcher dispatcher)
            {
                try
                {
                    dispatcher.Dispatch(new TerminalStoreSuccessAction());
                }
                catch (Exception ex)
                {
                    dispatcher.Dispatch(new TerminalStoreFailureAction());
                }
            }
        }
    }

}
