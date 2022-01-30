import sys
import re

def palindrom(text):
    if not text or text.strip() == "":
        return False
    
    # replace all characters except alphabet and German characters.
    text = re.sub(r'[^A-Za-zÄÜÖäüö]', "", text)
    text_length = len(text)
    
    # reverse text.
    reversed_text = text[text_length :: -1]

    # compare between text and reversed text
    return text.casefold() == reversed_text.casefold()

sys.modules[__name__] = palindrom