# exercise description goes here
# use question marks(?) if needed to help user complete the exercise
def func(words):
    count = 0
    for word in words:
        if ????????? and ?????????:
            ????????
    return count # dont forget to return a value to use on testing


# only the code above this line gets shown to the user
# TEST CODE START

# use this function for testing, user will see the testing output
# or u can import it with "from testing import test"
prefixPrinted = False
def test(args, got, expected):
    global prefixPrinted
    if not prefixPrinted:
        print("=== Testing your code ===")
        prefixPrinted = True
    status = "CORRECT" if got == expected else "FAILED"
    print(f"{status} input: {args} got: {got} expected: {expected}")

# example tests 
test(123, func(123), 1)
test(1234, func(1234), 42)
test(9999, func(9999), 10)
