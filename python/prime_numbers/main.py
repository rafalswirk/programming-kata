def isPrimeNumber(number_to_check):
    return bruteForcePrimeNumbers(number_to_check)

def bruteForcePrimeNumbers(number_to_check) :
    if number_to_check < 2 :
        return False
    
    for i in range(2, number_to_check) :
        if number_to_check % i == 0 :
            return False
    return True


print(isPrimeNumber(20002))