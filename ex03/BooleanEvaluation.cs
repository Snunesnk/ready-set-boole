namespace ReadySetBoole.Ex03 {
    public class BooleanEvaluation {
        public static bool Evaluate(string? str) {
            if (str == null)
                return false;

            bool expr = str[0] == '1' ? true : false;
            int index = 1;

            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];

                if (c != '1' && c != '0') {
                    expr = EvalExpr(expr, c, str[index]);
                    index++;
                    if (str[index] != '0' && str[index] != '1')
                        index++;
                }
            }

            return expr;
        }

        private static bool EvalExpr(bool expr, char c, char operand) {
            switch (c) {
                case '!':
                    if ((operand == '1' && expr == true) || (operand == '0' && expr == false))
                        return false;
                    return true;

                case '&':
                    if (operand == '0' || expr == false)
                        return false;
                    return true;

                case '|':
                    if (operand == '1' || expr == true)
                        return true;
                    return false;

                case '^':
                    if ((operand == '1' && expr == false) || (operand == '0' && expr == true))
                        return true;
                    return false;

                case '>':
                    if (expr == true && operand == '0')
                        return false;
                    return true;

                case '=':
                    if ((operand == '1' && expr == true) || (operand == '0' && expr == false))
                        return true;
                    return false;

                default:
                    Console.Error.WriteLine("Error: Invalid operand found: " + operand);
                    break;
            }

            return expr;
        }
    }
}