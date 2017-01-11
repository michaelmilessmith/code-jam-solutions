def play_lastword(word)
	chars = word.chars
	lastword = []
	lastword.push(chars.shift)
	puts lastword
	chars.each do |char|
		if [char, lastword[0]].sort[0] == lastword[0]
			lastword.unshift(char)
		else
			lastword.push(char)
		end
	end	
	lastword.join
end

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	word = stream[case_number].chomp
	result = play_lastword(word)
	out_file.puts "Case ##{case_number}: #{result}"
end