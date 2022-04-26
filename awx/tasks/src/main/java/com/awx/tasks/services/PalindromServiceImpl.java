package com.awx.tasks.services;

import org.springframework.stereotype.Service;

@Service
public class PalindromServiceImpl implements PalindromService {

    @Override
    public boolean checkText(String text) {

        if( text == null || text.isEmpty() ) {
            return false;
        }

        // Alle Zeichen ausser Buchstaben und Umlaute aus dem Text entfernen
        text = text.replaceAll("[^A-ZÄÜÖa-zäüö]", "");

        // Text "umkehren"
        final StringBuilder strb = new StringBuilder(text);
		final String reverseText = strb.reverse().toString();
        
        // Text mit dem umgekehrten Text vergleichen, Gross-/Kleinschreibung ignorieren
        return reverseText.equalsIgnoreCase(text);
    }
 
}