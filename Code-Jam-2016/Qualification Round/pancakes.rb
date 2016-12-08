def read_stack(stack)
	stack.reverse!
	flips = stack[0] == '+' ? 0 : 1
	current_pancake = stack[0]
	
	stack.each do |pancake|
		if pancake != current_pancake
			flips += 1
			current_pancake = pancake
		end
	end
	
	flips
end

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	pancake_stack = stream[case_number].chomp.chars
	result = read_stack(pancake_stack)
	out_file.puts "Case ##{case_number}: #{result}"
end