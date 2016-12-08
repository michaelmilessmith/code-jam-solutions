def process_case(credit, number_of_items, prices)
	(0...number_of_items).each do |i|
		price_to_find = credit - prices.shift
		j = prices.index(price_to_find)
		if j != nil
			return [i + 1, i + j + 2]
		end
	end
	puts "ERROR!"
end

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(0...number_of_cases).each do |case_number|
	start_index = case_number * 3
	
	credit = stream[start_index + 1].to_i
	number_of_items = stream[start_index + 2].to_i
	prices = stream[start_index + 3].split(' ').map {|price| price.to_i}
	
	answer = process_case(credit, number_of_items, prices)
	out_file.puts "Case ##{case_number + 1}: #{answer[0]} #{answer[1]}"
end

