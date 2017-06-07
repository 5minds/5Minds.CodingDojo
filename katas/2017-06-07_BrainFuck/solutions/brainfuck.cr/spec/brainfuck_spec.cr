require "./spec_helper"

describe Brainfuck do
  describe "integration" do
    let(:input) { IO::Memory.new(32) }

    it "prints nothing w/o a programm" do
      assert_equal "", run
    end

    it "prints null byte" do
      assert_equal "\0", run(".")
    end

    it "increment value" do
      assert_equal "\1", run("+.")
      assert_equal "\2", run("++.")
      assert_equal "A", run(("+" * 65) + ".")
    end

    it "decrement value" do
      assert_equal "\1", run("++-.")
      assert_equal "A", run(("+" * 66) + "-.")
    end

    it "increment pointer" do
      assert_equal "\1\0", run("+.>.")
    end

    it "decrement pointer" do
      assert_equal "\1\0\1", run("+.>.<.")
    end

    it "reads char from input" do
      input << " "
      input << " "
      input.rewind
      assert_equal " !", run(",.>,+.")
    end

    it "ignores non-brainfuck chars" do
      assert_equal "\1\0", run("+ . ignore - .")
    end

    it "loops" do
      assert_equal "\6", run("++[>+++<-]>.")
      assert_equal "\6", run("++ [> ++ +< - ] >.")

      assert_equal "", run(%{[[.-]]})
      assert_equal "\3\2\1", run(%{+++[[.-]]})
    end

    it "prints hello world" do
      assert_equal "Hello World!\n\r",
        run(%{
          ++++++++++
          [
          >+++++++>++++++++++>+++>+<<<<-
          ]                       Schleife zur Vorbereitung der Textausgabe
          >++.                    Ausgabe von 'H'
          >+.                     Ausgabe von 'e'
          +++++++.                'l'
          .                       'l'
          +++.                    'o'
          >++.                    Leerzeichen
          <<+++++++++++++++.      'W'
          >.                      'o'
          +++.                    'r'
          ------.                 'l'
          --------.               'd'
          >+.                     '!'
          >.                      Zeilenvorschub
          +++.                    Wagenrücklauf
        })
    end
  end

  private def run(program = "")
    output = String::Builder.new("")
    Brainfuck.run(program, output, input)
    output.to_s
  end
end
