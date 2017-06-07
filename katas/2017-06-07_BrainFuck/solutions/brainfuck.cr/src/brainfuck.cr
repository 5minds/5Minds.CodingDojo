require "./brainfuck/*"

module Brainfuck
  def self.run(program : String, output : IO = STDOUT, input : IO = STDIN)
    Program.new(program, output, input).run
  end

  class Tape
    def initialize
      @memory = [0]
      @index = 0u16
    end

    def change_value(value)
      @memory[@index] += value
    end

    def value
      @memory[@index]
    end

    def value=(value)
      @memory[@index] = value
    end

    def move_pointer(index)
      @index += index
      while @memory.size <= @index
        @memory << 0 
      end
    end
  end

  class Loops
    def initialize
      @stack = [] of UInt16
      @map = {} of UInt16 => UInt16
    end

    def open(position)
      @stack << position.to_u16
    end

    def close(position)
      self[@stack.pop] = position.to_u16
    end

    def [](position)
      @map[position]
    end

    def []=(open, close)
      @map[open] = close
      @map[close] = open
    end
  end

  class Program
    def initialize(@program : String, @output : IO, @input : IO)
    end

    def run
      instructions, loops = parse(@program.chars)
      interpret(@input, @output, instructions, loops)
    end

    private def parse(chars)
      instructions = [] of Char
      loops = Loops.new

      instructions = chars.map_with_index do |char, position|
        case char
        when '.'
          :print
        when ','
          :read
        when '+'
          :increment_value
        when '-'
          :decrement_value
        when '>'
          :increment_pointer
        when '<'
          :decrement_pointer
        when '['
          loops.open(position)
          :loop_begin
        when ']'
          loops.close(position)
          :loop_end
        else
          :noop
        end
      end

      {instructions.compact, loops}
    end

    private def interpret(input, output, instructions, loops)
      tape = Tape.new
      position = 0u16

      while position < instructions.size
        case instructions[position]
        when :print
          output.print tape.value.chr
        when :read
          tape.value = input.read_char.not_nil!.ord
        when :increment_value
          tape.change_value(1)
        when :decrement_value
          tape.change_value(-1)
        when :increment_pointer
          tape.move_pointer(1)
        when :decrement_pointer
          tape.move_pointer(-1)
        when :loop_begin
          position = loops[position] if tape.value == 0
        when :loop_end
          position = loops[position] if tape.value != 0
        when :noop
          # noop
        else
          raise "unknown instruction #{instructions[position]} at #{position}"
        end

        position += 1
      end
    end
  end
end
