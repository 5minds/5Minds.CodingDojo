// A Typescript function that checks whether a string is a palindrome

const checkPalindrome = (
    stringToCheckForPalindrome: string,
  ): boolean => {
    // Change the string into lower case and remove all non-alphanumeric characters with regex
      stringToCheckForPalindrome = stringToCheckForPalindrome
      .toLowerCase()
      .replace(/[^a-zA-Z0-9]+/g, '');
    let characterCountOfString = stringToCheckForPalindrome.length;
  
    // Check whether the string is empty or not. If it is empty we return false, as it is not a palindrome.
    if (stringToCheckForPalindrome === '') {
      console.log('Not a Palindrome');
      return false;
    }
  
    // Check if the length of the string is even or odd
    if (characterCountOfString % 2 === 0) {
      // Should it be even, we save half the length in our 'characterCountOfString'
      characterCountOfString = characterCountOfString / 2;
    } else {
      // If the length of the string is 1 then it becomes a palindrome.
      if (characterCountOfString === 1) {
        console.log('Palindrome');
        return true;
      } else {
        // If the length of the string is odd we ignore the middle character, by taking half-1.
        characterCountOfString = (characterCountOfString - 1) / 2;
      }
    }
    // Loop to compare the first character to the last character.
    for (let x = 0; x < characterCountOfString; x++) {
      // Compare the first character of the Array with the last and should they not match, we return false, as it is not a palindrome.
      // The 'x' index on the first half, compares against the slice(-1 -x) on the second half. -1 stands for the last index of the array, which we decrease by 'x' every loop. 
      if (
        stringToCheckForPalindrome[x] !=
        stringToCheckForPalindrome.slice(-1 - x)[0]
      ) {
        console.log('Not a Palindrome');
        return false;
      }
    }
    console.log('Palindrome');
    return true;
  };
  checkPalindrome('Abba');
  checkPalindrome('Lagerregal');
  checkPalindrome('Reliefpfeiler');
  checkPalindrome('Rentner');
  checkPalindrome('Dienstmannamtsneid');
  checkPalindrome('Ein string der keinen Sinn macht');
  