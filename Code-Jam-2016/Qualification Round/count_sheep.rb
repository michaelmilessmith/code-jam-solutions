def count_sheep(start_number)
	digets_left= [*0..9]
	(1..100).each do |i|
		current_number = start_number * i		
		digits = current_number.to_s.chars.map(&:to_i)
		digets_left.delete_if do |digit|
			digits.include? digit
		end
		#puts "N = #{current_number}, digits = #{digits}, digits remaining #{digets_left}"
		if digets_left.empty?
			return current_number
		end
	end
	return "INSOMNIA"
end



in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	#case_number = 5
	start_number = stream[case_number].to_i
	result = count_sheep(start_number)
	out_file.puts "Case ##{case_number}: #{result}"
end