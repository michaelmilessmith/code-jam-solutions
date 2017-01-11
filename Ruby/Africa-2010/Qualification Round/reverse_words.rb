in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	
	words = stream[case_number].split(' ').reverse.join(' ')
	
	out_file.puts "Case ##{case_number}: #{words}"
end