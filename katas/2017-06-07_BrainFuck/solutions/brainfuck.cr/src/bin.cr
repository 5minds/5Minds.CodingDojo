require "./brainfuck"

def run(program)
  Brainfuck.run(program)
end

if STDIN.tty?
  if ARGV.empty?
    abort "usage: brainfuck file.bf [..]"
  end

  ARGV.each do |filename|
    program = File.read(filename)

    run program
  end
else
  program = STDIN.gets_to_end
  run program
end
