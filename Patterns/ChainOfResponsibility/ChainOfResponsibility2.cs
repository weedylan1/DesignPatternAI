using System;

namespace DesignPatterns.ChainOfResponsibility.Advanced
{
    // Context passed through the chain
    public class RequestContext
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Action { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAuthorized { get; set; }
    }

    // Base handler
    public abstract class Handler
    {
        protected Handler Next { get; private set; }

        public Handler SetNext(Handler next)
        {
            Next = next;
            return next;
        }

        public void Handle(RequestContext context)
        {
            if (Process(context) && Next != null)
                Next.Handle(context);
        }

        // Return false to stop the chain
        protected abstract bool Process(RequestContext context);
    }

    // Concrete Handlers

    public class ValidationHandler : Handler
    {
        protected override bool Process(RequestContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Username) || string.IsNullOrWhiteSpace(context.Token))
            {
                Console.WriteLine("Validation failed: missing username or token.");
                return false;
            }
            Console.WriteLine("Validation passed.");
            return true;
        }
    }

    public class AuthenticationHandler : Handler
    {
        protected override bool Process(RequestContext context)
        {
            if (context.Token == "valid-token")
            {
                context.IsAuthenticated = true;
                Console.WriteLine($"User '{context.Username}' authenticated.");
                return true;
            }
            Console.WriteLine("Authentication failed.");
            return false;
        }
    }

    public class AuthorizationHandler : Handler
    {
        protected override bool Process(RequestContext context)
        {
            if (context.IsAuthenticated && context.Username == "admin")
            {
                context.IsAuthorized = true;
                Console.WriteLine("Authorization granted.");
                return true;
            }
            Console.WriteLine("Authorization denied.");
            return false;
        }
    }

    public class BusinessLogicHandler : Handler
    {
        protected override bool Process(RequestContext context)
        {
            if (context.IsAuthorized)
            {
                Console.WriteLine($"Executing '{context.Action}' for {context.Username}");
                return true;
            }

            Console.WriteLine("Cannot execute action: user not authorized.");
            return false;
        }
    }

    // Entry Point
    public static class Demo
    {
        public static void Run()
        {
            var pipeline = new ValidationHandler();
            pipeline
                .SetNext(new AuthenticationHandler())
                .SetNext(new AuthorizationHandler())
                .SetNext(new BusinessLogicHandler());

            Console.WriteLine("=== Test Case: Valid Admin ===");
            var context1 = new RequestContext { Username = "admin", Token = "valid-token", Action = "DeleteUser" };
            pipeline.Handle(context1);

            Console.WriteLine("\n=== Test Case: Missing Token ===");
            var context2 = new RequestContext { Username = "user1", Token = "", Action = "ReadData" };
            pipeline.Handle(context2);

            Console.WriteLine("\n=== Test Case: Authenticated but Unauthorized ===");
            var context3 = new RequestContext { Username = "user1", Token = "valid-token", Action = "DeleteUser" };
            pipeline.Handle(context3);
        }
    }
}
