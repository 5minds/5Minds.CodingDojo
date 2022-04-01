<?php

/**
 * Class ownLibrary.
 *
 * It included all our own libraries as static functions.
 *
 */
class ownLibrary {

    /**
     * Check any word or sentence whether it palindrome is.
     *
     * @param $word_to_check
     * @return string
     */
    public static function checkWord( $word_to_check ) {

        // Ignore chars.
        $ignore_chars = ['!',',',':','.','?',' '];

        // Change the text to lower case.
        $changed_word_to_check = utf8_decode(strtolower( $word_to_check ));

        // Definition of two arrays.
        $word_array = $new_word_array = [];

        // Delete the ignore charachters ...
        for ( $i = 0; $i < strlen( $changed_word_to_check ); $i++ ) {
            $selected_character = substr( $changed_word_to_check , $i , 1 );
            if ( array_search( $selected_character , $ignore_chars ) === false ) {
                $word_array[ ] = $selected_character;
            }
        }
        $changed_word_to_check = implode( $word_array );

        // Save the reversed text in a new variable ...
        $index = 0;
        for ( $i = count( $word_array ) - 1; $i >=0 ; $i-- ) {
            $new_word_array[ $index ] = $word_array[ $i ];
            $index++;
        }
        $new_word = implode( '' , $new_word_array );

        // Check the word or sentence and return the output ...
        if ( $changed_word_to_check === $new_word ) {
            return '"' . $word_to_check . '" ist ein Palindrom!';
        }
        else {
            return '"' . $word_to_check . '" ist <b>KEIN</b> Palindrom!';
        }
    }
}
